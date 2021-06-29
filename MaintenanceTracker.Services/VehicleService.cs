using MaintenanceTracker.Data;
using MaintenanceTracker.Models;
using MaintenanceTrackerMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Services
{
    public class VehicleService
    {
        public bool CreateVehicle(VehicleCreate model)
        {
            var entity =
                new Vehicle()
                {
                    Year = model.Year,
                    Make = model.Make,
                    VehicleModel = model.VehicleModel,
                    Displacement = model.Displacement,
                    IsAutomatic = model.IsAutomatic,
                    Odometer = model.Odometer
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Vehicles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VehicleListItem> GetVehicles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Vehicles
                        .Select(
                            e =>
                                new VehicleListItem
                                {
                                    VehicleId = e.VehicleId,
                                    Year = e.Year,
                                    Make = e.Make,
                                    VehicleModel = e.VehicleModel
                                }
                        );

                return query.ToArray();
            }
        }

        public VehicleDetail GetVehicleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vehicles
                        .Single(e => e.VehicleId == id);
                return
                    new VehicleDetail
                    {
                        VehicleId = entity.VehicleId,
                        Year = entity.Year,
                        Make = entity.Make,
                        VehicleModel = entity.VehicleModel,
                        Displacement = entity.Displacement,
                        IsAutomatic = entity.IsAutomatic,
                        Odometer = entity.Odometer
                    };
            }
        }
    }
}
