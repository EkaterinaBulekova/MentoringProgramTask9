﻿using LinqToDB.Mapping;
using System.Collections.Generic;

namespace DALLinq2db.DataModels
{
    [Table(Name = "Suppliers")]
    public class Supplier
    {
        [PrimaryKey, Identity] public int SupplierID;
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
        [Column] public string HomePage;

        [Association(ThisKey = "SupplierID", OtherKey = "SupplierID")]
        public List<Product> Products;
    }
}
