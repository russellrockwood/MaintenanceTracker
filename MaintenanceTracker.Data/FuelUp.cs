using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Data
{
    public class FuelUp
    {
        [Key]
        public int FuelUpId { get; set; }

        [Required]
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public double Miles { get; set; }

        [Required]
        public double Gallons { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        

        public double Mpg 
        { 
            get
            {
                return Math.Round(Miles / Gallons, 2);
            }
        }

        //public SelectList VehicleOptions {get; set;}
    }
}
