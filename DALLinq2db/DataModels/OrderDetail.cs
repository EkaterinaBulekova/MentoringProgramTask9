using LinqToDB.Mapping;

namespace DALLinq2db.DataModels
{

    [Table(Name = "Order Details")]
    public class OrderDetail
    {
        [PrimaryKey] public int OrderID;
        [PrimaryKey] public int ProductID;
        [Column] public decimal UnitPrice;
        [Column] public short Quantity;
        [Column] public double Discount;

        [Association(ThisKey = "OrderID", OtherKey = "OrderID")] public Order Order;
        [Association(ThisKey = "ProductID", OtherKey = "ProductID")] public Product Product;
    }

}
