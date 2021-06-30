using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Data
{
    public class VehicleMaintenance
    {
        [Key]
        public int VehicleMaintenanceId { get; set; }

        [Required]
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [Required]
        public string MaintenanceName { get; set; }

        [Required]
        public string ShopName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Notes { get; set; }

        //public DateTimeOffset ServiceDate { get; set; }
        //public int Odometer { get; set; }



    }
}
