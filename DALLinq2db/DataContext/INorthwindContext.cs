using System;
using LinqToDB;
using DALLinq2db.DataModels;

namespace DALLinq2db.DataContext
{
    public interface INorthwindContext: IDisposable
    {
        ITable<Product> Products { get; }

        ITable<Category> Categories { get; }

        ITable<Supplier> Suppliers { get; }

        ITable<EmployeeTerritory> EmployeeTerritories { get; }

        ITable<Order> Orders { get; }

        ITable<OrderDetail> OrderDetails { get; }

        object InsertEntityWith<T>(T item);
        int InsertEntity<T>(T item);

        int UpdateEntity<T>(T item);

        int DeleteEntity<T>(T item);
    }
}