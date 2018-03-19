using LinqToDB.Mapping;
using System.Collections.Generic;

namespace DALLinq2db.DataModels
{
    [Table(Name = "Shippers")]
    public class Shipper : EntityBase<int>
    {
        [PrimaryKey, Identity] public int ShipperID;
        [Column, NotNull] public string CompanyName;
        [Column] public string Phone;

        [Association(ThisKey = "ShipperID", OtherKey = "ShipVia")]
        public List<Order> Orders;

        protected override int Key => ShipperID;
    }

}
