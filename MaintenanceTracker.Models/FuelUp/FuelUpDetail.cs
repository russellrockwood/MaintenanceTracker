﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Models.FuelUp
{
    public class FuelUpDetail
    {
        public int VehicleId { get; set; }

        public decimal Price { get; set; }

        public double Miles { get; set; }

        public double Gallons { get; set; }

        [Display(Name ="Date")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public double Mpg
        {
            get
            {
                return Miles / Gallons;
            }
        }
    }
}
