using DALLinq2db.DataModels;

namespace DALLinq2db.Models
{
    public class RegionStatistic
    {
        public Region Region { get; set; }
        public int EmployeesCount { get; set; }
    }
}
