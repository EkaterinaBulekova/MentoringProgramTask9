using System;
using System.Collections.Generic;
using System.Linq;
using DALLinq2db.DataContext;
using DALLinq2db.Models;
using DALLinq2db.DataModels;
using LinqToDB;

namespace DALLinq2db.Repositories
{
    public class Repository : IRepository
    {
        private readonly INorthwindContext _context;

        public Repository(INorthwindContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductsWithCategorySuplier()
        {
            return _context.Products;
        }

        public IEnumerable<RegionStatistic> GetCountEmployeesByRegions()
        {
            var preresult = _context.EmployeeTerritories.ToList()
                .GroupBy(_ => _.Territory.Region);
            var result = preresult
                .Select(_ => new RegionStatistic()
                {
                   Region = _.Key,
                   EmployeesCount = _.GroupBy(t => t.Employee.EmployeeID).Count()
                })
                .ToList();
            return result;
        }

        public IEnumerable<EmployeeShippers> GetEmployeesWithShipperses()
        {
            return _context.Orders.ToList()
                .GroupBy(_ => _.Employee)
                .Select(_ => new EmployeeShippers
                {
                    Employee = _.Key,
                    Shippers = _.Select(t => new Shipper()
                    {
                        ShipperID = t.Shipper.ShipperID,
                        CompanyName = t.Shipper.CompanyName
                    }).Distinct()
                }).ToList();

        }

        public IEnumerable<EmployeeRegions> GetEmployeesWithRegions()
        {
            return _context.EmployeeTerritories.ToList()
                .GroupBy(_ => _.Employee)
                .Select(_ => new EmployeeRegions
                {
                    Employee = _.Key,
                    Regions = _.Select(t => new Region
                    {
                        RegionID = t.Territory.RegionID,
                        RegionDescription = t.Territory.Region.RegionDescription
                    }).Distinct()
                }).ToList();
        }

        public int InsertNewEmployee(Employee employee, IEnumerable<Territory> territories)
        {
            var status = 0;
            var employeeId = _context.InsertEntityWith(employee);
            if (employeeId == null) return status;
            status++;
            status += territories.Select(territory => new EmployeeTerritory
                {
                    EmployeeID = Convert.ToInt32(employeeId),
                    TerritoryID = territory.TerritoryID
                })
                .Select(empter => _context.InsertEntity(empter))
                .Sum();
            return status;
        }

        public int MoveProductsToCategory(IEnumerable<Product> products, Category category)
        {
            var status = 0;
            foreach (var product in products)
            {
                product.CategoryID = category.CategoryID;
                status += _context.UpdateEntity(product);
            }

            return status;
        }

        public int InsertProductsWithCategorySuplier(List<Product> products)
        {
            var status = 0;

            foreach (var product in products)
            {
                if (product.Category.CategoryName == null || product.Supplier.CompanyName == null)
                    throw new ArgumentException(ExceptionMessages.ArgumentException);
                var category = _context.Categories.FirstOrDefault(_ => _.CategoryName == product.Category.CategoryName);
                product.CategoryID = category?.CategoryID ?? Convert.ToInt32(_context.InsertEntityWith(product.Category));
                var supplier = _context.Suppliers.FirstOrDefault(_ => _.CompanyName == product.Supplier.CompanyName);
                product.SupplierID = supplier?.SupplierID ?? Convert.ToInt32(_context.InsertEntityWith(product.Supplier));

                status += _context.InsertEntity(product);
            }

            return status;
        }

        public int ChangeProductByProduct(Product product1, Product product2)
        {
            var failOrders = string.Join(",", _context.OrderDetails
                .Where(_ => _.Product.ProductID == product1.ProductID
                            && _.Order.ShippedDate == null
                            && _context.OrderDetails
                                .Any(d => d.OrderID == _.OrderID && d.ProductID == product2.ProductID))
                .Select(_ => _.OrderID.ToString()));
            var status = _context.OrderDetails
                .Where(_ => _.Product.ProductID == product1.ProductID 
                            && _.Order.ShippedDate == null 
                            && !_context.OrderDetails
                                .Any(d => d.OrderID == _.OrderID && d.ProductID == product2.ProductID))
                .Set(_ => _.ProductID, _ => product2.ProductID).Update();

            if (!string.IsNullOrWhiteSpace(failOrders))
            {
                Console.WriteLine(ExceptionMessages.CannotChangeProductAlreadyExists, product1.ProductName, product2.ProductName, failOrders, product2.ProductName);
            }

            return status;
        }
    }
}
