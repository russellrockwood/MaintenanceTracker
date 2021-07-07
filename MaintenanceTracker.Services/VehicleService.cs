using MaintenanceTracker.Data;
using MaintenanceTracker.Models;
using MaintenanceTracker.Models.FuelUp;
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
        private readonly Guid _userId;

        public VehicleService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateVehicle(VehicleCreate model)
        {
            var entity =
                new Vehicle()
                {
                    OwnerId = _userId,
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
                        .Where(e => e.OwnerId == _userId)
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

        public IEnumerable<Vehicle> GetVehiclesList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx
                        .Vehicles
                        .Where(e => e.OwnerId == _userId)
                        .ToList();
            }
        }

        public VehicleDetail GetVehicleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vehicles
                        .Single(e => e.VehicleId == id && e.OwnerId == _userId);
                return
                    new VehicleDetail
                    {
                        VehicleId = entity.VehicleId,
                        Year = entity.Year,
                        Make = entity.Make,
                        VehicleModel = entity.VehicleModel,
                        Displacement = entity.Displacement,
                        IsAutomatic = entity.IsAutomatic,
                        Odometer = entity.Odometer,
                        FuelEconomy = entity.FuelEconomy,                        
                    };
            }
        }

        public IEnumerable<FuelUp> GetFuelUpHistory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vehicles
                        .Single(e => e.VehicleId == id && e.OwnerId == _userId);
                
                return entity.FuelUps.ToList();
            }
        }

        public IEnumerable<VehicleMaintenance> GetMaintenanceHistory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vehicles
                        .Single(e => e.VehicleId == id && e.OwnerId == _userId);

                return entity.MaintenanceRecord.ToList();
            }
        }

        public bool UpdateVehicle(VehicleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vehicles
                        .Single(e => e.VehicleId == model.VehicleId && e.OwnerId == _userId);
                
                entity.Year = model.Year;
                entity.Make = model.Make;
                entity.VehicleModel = model.VehicleModel;
                entity.Displacement = model.Displacement;
                entity.IsAutomatic = model.IsAutomatic;
                entity.Odometer = model.Odometer;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteVehicle(int vehicleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vehicles
                        .Single(e => e.VehicleId == vehicleId && e.OwnerId == _userId);

                ctx.Vehicles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
