using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Models
{
    public class VehicleListItem
    {
        public int VehicleId { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string VehicleModel { get; set; }
    }
}
