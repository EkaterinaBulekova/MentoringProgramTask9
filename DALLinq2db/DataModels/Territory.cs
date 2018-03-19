using LinqToDB.Mapping;
using System.Collections.Generic;

namespace DALLinq2db.DataModels
{
    [Table(Name = "Territories")]
    public class Territory
    {
        [PrimaryKey, NotNull] public string TerritoryID;
        [Column, NotNull] public string TerritoryDescription;
        [Column] public int RegionID;

        public EmployeeTerritory EmployeeTerritory { get; set; }

        [Association(ThisKey = "TerritoryID", OtherKey = "TerritoryID")]
        public List<EmployeeTerritory> EmployeeTerritories;

        [Association(ThisKey = "RegionID", OtherKey = "RegionID")]
        public Region Region;
    }
}
