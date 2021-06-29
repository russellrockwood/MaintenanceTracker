using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Models
{
    public class VehicleEdit
    {
        public int VehicleId { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }

        [Display(Name = "Model")]
        public string VehicleModel { get; set; }
        public double Displacement { get; set; }
        public bool IsAutomatic { get; set; }
        public double Odometer { get; set; }
    }
}
