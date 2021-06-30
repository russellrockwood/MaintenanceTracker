using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Models.VehicleMaintenance
{
    public class VehicleMaintenanceListItem
    {
        public int VehicleMaintenanceId { get; set; }

        public int VehicleId { get; set; }

        [Display(Name ="Service Description")]
        public string MaintenanceName { get; set; }

        public decimal Price { get; set; }
    }
}
