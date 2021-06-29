using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Models.FuelUp
{
    public class FuelUpEdit
    {
        public int FuelUpId { get; set; }

        public int VehicleId { get; set; }

        public decimal Price { get; set; }

        public double Miles { get; set; }

        public double Gallons { get; set; }
    }
}
