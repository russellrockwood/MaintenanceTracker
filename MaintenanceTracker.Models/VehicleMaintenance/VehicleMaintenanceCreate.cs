using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Models.VehicleMaintenance
{
    public class VehicleMaintenanceCreate
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        [Display(Name ="Service Description")]
        public string MaintenanceName { get; set; }

        [Required]
        public string ShopName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Notes { get; set; }
    }
}
