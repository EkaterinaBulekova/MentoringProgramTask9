using System.Collections.Generic;
using DALLinq2db.DataModels;

namespace DALLinq2db.Models
{
    public class EmployeeShippers
    {
        public Employee Employee { get; set; }
        public IEnumerable<Shipper> Shippers { get; set; }

    }
}
