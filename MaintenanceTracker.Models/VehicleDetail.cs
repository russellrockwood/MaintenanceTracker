using MaintenanceTracker.Models.FuelUp;
using MaintenanceTracker.Models.VehicleMaintenance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Models
{
    public class VehicleDetail
    {
        
        public int VehicleId { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        
        [Display(Name ="Model")]
        public string VehicleModel { get; set; }
        public double Displacement { get; set; }
        public bool IsAutomatic { get; set; }
        public double Odometer { get; set; }

        public double FuelEconomy { get; set; }

        //public virtual List<FuelUpDetail> FuelUps { get; set; }
        //public virtual List<VehicleMaintenanceDetail> MaintenanceRecord { get; set; }
    }
}
