using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using DALLinq2db.DataContext;
using DALLinq2db.Repositories;
using DALLinq2db.DataModels;

namespace DALLinq2db.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private INorthwindContext _context;
        private IRepository _repository;

        [TestInitialize]
        public void NorthwindTestInitialize()
        {
            _context = new NorthwindContext("Northwind");
            _repository = new Repository(_context);

        }

        [TestCleanup]
        public void NorthwindTestCleanup()
        {
            _context.Dispose();
        }

        [TestMethod]
        public void CanGetProductsWithCategorySuplier()
        {
            var products = new Repository(_context).GetProductsWithCategorySuplier().ToList();
            foreach (var product in products)
            {
                Console.WriteLine(Messages.Output, product.ProductName, product.Category.CategoryName, product.Supplier.CompanyName);
            }

            Assert.IsTrue(products.Any());
        }

        [TestMethod]
        public void CanGetEmployeesWithRegions()
        {
            var emloyees = _repository.GetEmployeesWithRegions().ToList();
                foreach (var employee in emloyees)
                {
                    Console.WriteLine(Messages.Output, employee.Employee.FirstName, employee.Employee.LastName, string.Join(",", employee.Regions.Select(_=>_.RegionDescription)));
                }
            Assert.IsTrue(emloyees.Any());
        }

        [TestMethod]
        public void CanGetCountEmployeesByRegions()
        {
            var regions = _repository.GetCountEmployeesByRegions().ToList();
            foreach (var region in regions)
            {
                Console.WriteLine(Messages.Output, region.Region.RegionDescription, region.EmployeesCount,"");
            }
            Assert.IsTrue(regions.Any());
        }

        [TestMethod]
        public void CanGetEmployeesWithShipperses()
        {
            var employees = _repository.GetEmployeesWithShipperses().ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine(Messages.Output, employee.Employee.FirstName, employee.Employee.LastName, string.Join(",", employee.Shippers.Select(_ => _.CompanyName)));
            }
            Assert.IsTrue(employees.Any());
        }

        [TestMethod]
        public void CanInsertNewEmployee()
        {
            var employee = new Employee
            {
                FirstName = "Mark",
                LastName = "Simpson",
                City = "London"
            };
            var territories = new List<Territory>
            {
                new Territory
                {
                    RegionID = 1,
                    TerritoryID = "02903"
                },
                new Territory
                {
                    RegionID = 1,
                    TerritoryID = "03049"
                },
                new Territory
                {
                    RegionID = 1,
                    TerritoryID ="03801"
                },
                new Territory
                {
                    RegionID = 1,
                    TerritoryID ="06897"
                },
                new Territory
                {
                    RegionID = 1,
                    TerritoryID ="07960"
                }
            };
            var status = _repository.InsertNewEmployee(employee, territories);

            Assert.AreEqual(territories.Count+1, status);
        }

        [TestMethod]
        public void CanMoveProductsToCategory()
        {
            var category = new Category { CategoryID = 2 };
            var products = _repository.GetProductsWithCategorySuplier().Take(5).ToList();
            var status = _repository.MoveProductsToCategory(products, category);

            Assert.AreEqual(products.Count, status);
        }

        [TestMethod]
        public void CanInsertProductsWithCategorySuplier()
        {
            var products = new List<Product>
            {
                new Product
                {
                    ProductName = "Some product",
                    UnitPrice = 27,
                    UnitsInStock = 100,
                    Category = new Category
                    {
                        CategoryName = "Some category"
                    },
                    Supplier = new Supplier
                    {
                        CompanyName = "Some company name",
                        ContactName = "Some contact name"
                    }
                },
                new Product
                {
                    ProductName = "Another product",
                    UnitPrice = 27,
                    UnitsInStock = 100,
                    CategoryID = 1,
                    Category = new Category
                    {
                        CategoryName = "Third category"
                    },
                    SupplierID = 1,
                    Supplier = new Supplier
                    {
                        CompanyName = "Third supplier"
                    }
                }
            };
            var status = _repository.InsertProductsWithCategorySuplier(products);

            Assert.AreEqual(products.Count, status);
        }

        [TestMethod]
        public void CanChangeProductByProduct()
        {
            var oldProduct = 
                new Product
                {
                    ProductID = 5
                };
            var newProduct = 
                new Product
                {
                    ProductID = 6
                };
            
            var status = _repository.ChangeProductByProduct(oldProduct, newProduct);

            Assert.IsTrue(status > 0);
        }
    }
}
