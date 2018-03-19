using LinqToDB.Mapping;

namespace DALLinq2db.DataModels
{
    [Table("EmployeeTerritories")]
    public class EmployeeTerritory
    {
        [PrimaryKey] public int EmployeeID;
        [PrimaryKey, NotNull] public string TerritoryID;

        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID")] public Employee Employee;
        [Association(ThisKey = "TerritoryID", OtherKey = "TerritoryID")] public Territory Territory;
    }
}
