using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Data
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Max 50 characters")]
        public string Make { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Max 50 characters")]
        [Display(Name ="Model")]
        public string VehicleModel { get; set; }

        [Required]
        public double Displacement { get; set; }

        [Required]
        public bool IsAutomatic { get; set; }

        [Required]
        public double Odometer { get; set; }

        public double FuelEconomy
        {
            get
            {
                double combinedMpg = 0;
                foreach (var item in FuelUps)
                {
                    combinedMpg += item.Mpg;
                }

                return combinedMpg / FuelUps.Count;
            }
        }

        public virtual List<FuelUp> FuelUps { get; set; }
        public virtual List<VehicleMaintenance> MaintenanceRecord { get; set; }
        
    }
}
