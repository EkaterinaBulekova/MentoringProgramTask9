using LinqToDB;
using LinqToDB.Data;
using DALLinq2db.DataModels;

namespace DALLinq2db.DataContext
{
    public class NorthwindContext : DataConnection, INorthwindContext
    {
        public NorthwindContext(string connectionString) 
            : base (connectionString) { }

        public virtual ITable<Product> Products =>
            GetTable<Product>()
                .LoadWith(_ => _.Category)
                .LoadWith(_ => _.Supplier);

        public virtual ITable<Category> Categories =>
            GetTable<Category>();

        public virtual ITable<Supplier> Suppliers =>
            GetTable<Supplier>();

        public virtual ITable<EmployeeTerritory> EmployeeTerritories =>
            GetTable<EmployeeTerritory>()
                .LoadWith(_ => _.Employee)
                .LoadWith(_ => _.Territory.Region);

        public virtual ITable<Order> Orders =>
            GetTable<Order>()
                .LoadWith(_ => _.Employee)
                .LoadWith(_ => _.Shipper);

        public virtual ITable<OrderDetail> OrderDetails =>
            GetTable<OrderDetail>()
                .LoadWith(_ => _.Order)
                .LoadWith(_ => _.Product);

        public int InsertEntity<T>(T item)
        {
            return this.Insert(item);
        }

        public object InsertEntityWith<T>(T item)
        {
            return this.InsertWithIdentity(item);
        }

        public int UpdateEntity<T>(T item)
        {
            return this.Update(item);
        }

        public int DeleteEntity<T>(T item)
        {
            return this.Delete(item);
        }
    }
}
