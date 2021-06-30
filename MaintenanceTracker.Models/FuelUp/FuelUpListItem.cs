using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Models.FuelUp
{
    public class FuelUpListItem
    {
        public int VehicleId { get; set; }

        public decimal Price { get; set; }

        public double Gallons { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
