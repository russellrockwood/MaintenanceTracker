using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Models.FuelUp
{
    public class FuelUpCreate
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public double Miles { get; set; }

        [Required]
        public double Gallons { get; set; }
    }
}
