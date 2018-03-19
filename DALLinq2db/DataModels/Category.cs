using LinqToDB.Mapping;
using System.Collections.Generic;

namespace DALLinq2db.DataModels
{
    [Table("Categories")]
    public class Category
    {
        [PrimaryKey, Identity] public int CategoryID;
        [Column, NotNull] public string CategoryName;
        [Column] public string Description;
        [Column] public byte[] Picture;

        [Association(ThisKey = "CategoryID", OtherKey = "CategoryID")]
        public List<Product> Products;
    }
}
