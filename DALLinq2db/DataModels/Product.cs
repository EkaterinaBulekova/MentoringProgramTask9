using LinqToDB.Mapping;
using System.Collections.Generic;

namespace DALLinq2db.DataModels
{
    [Table(Name = "Products")]
    public class Product
    {
        [PrimaryKey, Identity] public int ProductID;
        [Column, NotNull] public string ProductName;
        [Column] public int? SupplierID;
        [Column] public int? CategoryID;
        [Column] public string QuantityPerUnit;
        [Column] public decimal? UnitPrice;
        [Column] public short? UnitsInStock;
        [Column] public short? UnitsOnOrder;
        [Column] public short? ReorderLevel;
        [Column(IsDiscriminator = true)] public bool Discontinued;

        [Association(ThisKey = "ProductID", OtherKey = "ProductID")] public List<OrderDetail> OrderDetails;
        [Association(ThisKey = "CategoryID", OtherKey = "CategoryID")] public Category Category;
        [Association(ThisKey = "SupplierID", OtherKey = "SupplierID")] public Supplier Supplier;
    }
}
