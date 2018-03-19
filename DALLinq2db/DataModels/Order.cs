using LinqToDB.Mapping;
using System;
using System.Collections.Generic;

namespace DALLinq2db.DataModels
{
    [Table(Name = "Orders")]
    public class Order : EntityBase<int>
    {
        [PrimaryKey, Identity] public int OrderID;
        [Column] public string CustomerID;
        [Column] public int? EmployeeID;
        [Column] public DateTime? OrderDate;
        [Column] public DateTime? RequiredDate;
        [Column] public DateTime? ShippedDate;
        [Column] public int? ShipVia;
        [Column] public decimal Freight;
        [Column] public string ShipName;
        [Column] public string ShipAddress;
        [Column] public string ShipCity;
        [Column] public string ShipRegion;
        [Column] public string ShipPostalCode;
        [Column] public string ShipCountry;

        [Association(ThisKey = "OrderID", OtherKey = "OrderID")] public List<OrderDetail> OrderDetails;
        [Association(ThisKey = "CustomerID", OtherKey = "CustomerID", CanBeNull = false)] public Customer Customer;
        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID")] public Employee Employee;
        [Association(ThisKey = "ShipVia", OtherKey = "ShipperID")] public Shipper Shipper;

        public OrderDetail OrderDetail { get; set; }

        protected override int Key => OrderID;
    }
}
