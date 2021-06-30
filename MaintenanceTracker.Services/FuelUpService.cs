using MaintenanceTracker.Data;
using MaintenanceTracker.Models.FuelUp;
using MaintenanceTrackerMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Services
{
    public class FuelUpService
    {
        public bool CreateFuelUp(FuelUpCreate model)
        {
            var entity =
                new FuelUp()
                {
                    VehicleId = model.VehicleId,
                    Price = model.Price,
                    Miles = model.Miles,
                    Gallons = model.Gallons,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FuelUps.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FuelUpListItem> GetFuelUps()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .FuelUps
                        .Select(
                            e =>
                            new FuelUpListItem 
                            { 
                                VehicleId = e.VehicleId,
                                Price = e.Price,
                                Gallons = e.Gallons,
                                CreatedUtc = e.CreatedUtc,
                                ModifiedUtc = e.ModifiedUtc
                            }
                        );

                return query.ToArray();
            }
        }
    }
}
