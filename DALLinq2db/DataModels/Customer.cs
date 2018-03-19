using LinqToDB.Mapping;
using System.Collections.Generic;

namespace DALLinq2db.DataModels
{
    [Table(Name = "Customers")]
    public class Customer : EntityBase<string>
    {
        [PrimaryKey] public string CustomerID;
        [Column, NotNull] public string CompanyName;
        [Column] public string ContactName;
        [Column] public string ContactTitle;
        [Column] public string Address;
        [Column] public string City;
        [Column] public string Region;
        [Column] public string PostalCode;
        [Column] public string Country;
        [Column] public string Phone;
        [Column] public string Fax;

        [Association(ThisKey = "CustomerID", OtherKey = "CustomerID")]
        public List<Order> Orders;

        protected override string Key => CustomerID;
    }
}
