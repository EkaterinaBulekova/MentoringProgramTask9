using LinqToDB.Mapping;
using System;
using System.Collections.Generic;

namespace DALLinq2db.DataModels
{
    [Table(Name = "Employees")]
    public class Employee : EntityBase<int>
    {
        [PrimaryKey, Identity] public int EmployeeID;
        [Column, NotNull] public string LastName;
        [Column, NotNull] public string FirstName;
        [Column] public string Title;
        [Column] public string TitleOfCourtesy;
        [Column] public DateTime? BirthDate;
        [Column] public DateTime? HireDate;
        [Column] public string Address;
        [Column] public string City;
        [Column] public string Region;
        [Column] public string PostalCode;
        [Column] public string Country;
        [Column] public string HomePhone;
        [Column] public string Extension;
        [Column] public byte[] Photo;
        [Column] public string Notes;
        [Column] public int? ReportsTo;
        [Column] public string PhotoPath;

        [Association(ThisKey = "EmployeeID", OtherKey = "ReportsTo")] public List<Employee> Employees;
        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID")] public List<EmployeeTerritory> EmployeeTerritories;
        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID")] public List<Order> Orders;
        [Association(ThisKey = "ReportsTo", OtherKey = "EmployeeID")] public Employee ReportsToEmployee;

        public Employee Employee2 { get; set; }
        public Order Order { get; set; }
        public EmployeeTerritory EmployeeTerritory { get; set; }

        protected override int Key => EmployeeID;
    }
}
