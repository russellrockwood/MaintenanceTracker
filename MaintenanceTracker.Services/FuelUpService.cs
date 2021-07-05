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
        private readonly Guid _userId;

        public FuelUpService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateFuelUp(FuelUpCreate model)
        {
            var entity =
                new FuelUp()
                {
                    OwnerId = _userId,
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
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                            new FuelUpListItem 
                            { 
                                FuelUpId = e.FuelUpId,
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
                        .Single(e => e.FuelUpId == id && e.OwnerId == _userId);

                return new FuelUpDetail
                {
                    FuelUpId = entity.FuelUpId,
                    VehicleId = entity.VehicleId,
                    Price = entity.Price,
                    Miles = entity.Miles,
                    Gallons = entity.Gallons,
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
                        .Single(e => e.FuelUpId == model.FuelUpId && e.OwnerId == _userId);

                entity.VehicleId = model.VehicleId;
                entity.Price = model.Price;
                entity.Miles = model.Miles;
                entity.Gallons = model.Gallons;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

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
                        .Single(e => e.FuelUpId == id && e.OwnerId == _userId);

                ctx.FuelUps.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
