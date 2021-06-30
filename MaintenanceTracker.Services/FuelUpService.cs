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

        public FuelUpDetail GetFuelUpById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FuelUps
                        .Single(e => e.FuelUpId == id);

                return new FuelUpDetail
                {
                    VehicleId = entity.VehicleId,
                    Price = entity.Price,
                    Miles = entity.Miles,
                    Gallons = entity.Miles,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc,
                    Mpg = entity.Mpg
                };
            }
        }

        public bool UpdateFuelUp(FuelUpEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FuelUps
                        .Single(e => e.FuelUpId == model.FuelUpId);

                entity.VehicleId = model.VehicleId;
                entity.Price = model.Price;
                entity.Miles = model.Miles;
                entity.Gallons = model.Gallons;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveFuelUp(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FuelUps
                        .Single(e => e.FuelUpId == id);

                ctx.FuelUps.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
