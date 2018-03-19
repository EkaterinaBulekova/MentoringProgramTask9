using System.Collections.Generic;
using DALLinq2db.DataModels;
using DALLinq2db.Models;

namespace DALLinq2db.Repositories
{
    public interface IRepository
    {
        IEnumerable<Product> GetProductsWithCategorySuplier();
        IEnumerable<RegionStatistic> GetCountEmployeesByRegions();
        IEnumerable<EmployeeShippers> GetEmployeesWithShipperses();
        IEnumerable<EmployeeRegions> GetEmployeesWithRegions();
        int InsertNewEmployee(Employee employee, IEnumerable<Territory> territories);
        int MoveProductsToCategory(IEnumerable<Product> products, Category category);
        int InsertProductsWithCategorySuplier(List<Product> products);
        int ChangeProductByProduct(Product product1, Product product2);
    }
}
