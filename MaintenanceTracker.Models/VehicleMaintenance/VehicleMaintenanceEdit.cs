﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Models.VehicleMaintenance
{
    public class VehicleMaintenanceEdit
    {
        public int VehicleMaintenanceId { get; set; }
        public int VehicleId { get; set; }

        [Display(Name = "Service Description")]
        public string MaintenanceName { get; set; }

        public string ShopName { get; set; }

        public decimal Price { get; set; }

        public string Notes { get; set; }
    }
}
