using LinqToDB.Mapping;
using System.Collections.Generic;

namespace DALLinq2db.DataModels
{
    [Table(Name = "Region")]
    public class Region : EntityBase<int>
    {
        [PrimaryKey] public int RegionID;
        [Column, NotNull] public string RegionDescription;

        [Association(ThisKey = "RegionID", OtherKey = "RegionID")]
        public List<Territory> Territories;

        protected override int Key => RegionID;
    }
}
