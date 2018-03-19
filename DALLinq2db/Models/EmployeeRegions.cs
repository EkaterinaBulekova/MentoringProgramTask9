using System.Collections.Generic;
using DALLinq2db.DataModels;

namespace DALLinq2db.Models
{
    public class EmployeeRegions
    {
        public Employee Employee { get; set; }
        public IEnumerable<Region> Regions { get; set; }
    }
}
