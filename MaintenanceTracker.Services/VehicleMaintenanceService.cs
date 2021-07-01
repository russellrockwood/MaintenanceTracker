﻿using MaintenanceTracker.Data;
using MaintenanceTracker.Models.VehicleMaintenance;
using MaintenanceTrackerMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Services
{
    public class VehicleMaintenanceService
    {
        public bool CreateVehicleMaintenance(VehicleMaintenanceCreate model)
        {
            var entity =
                new VehicleMaintenance
                {
                    VehicleId = model.VehicleId,
                    MaintenanceName = model.MaintenanceName,
                    ShopName = model.ShopName,
                    Price = model.Price,
                    Notes = model.Notes
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.VehicleMaintenanceDbSet.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VehicleMaintenanceListItem> GetVehicleMaintenanceList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .VehicleMaintenanceDbSet
                        .Select(e =>
                            new VehicleMaintenanceListItem
                            {
                                VehicleMaintenanceId = e.VehicleMaintenanceId,
                                VehicleId = e.VehicleId,
                                MaintenanceName = e.MaintenanceName,
                                Price = e.Price
                            }
                        );
                return query.ToList();
            }
        }

        public VehicleMaintenanceDetail GetVehicleMaintenanceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .VehicleMaintenanceDbSet
                        .Single(e => e.VehicleMaintenanceId == id);

                return new VehicleMaintenanceDetail
                {
                    VehicleMaintenanceId = entity.VehicleMaintenanceId,
                    VehicleId = entity.VehicleId,
                    MaintenanceName = entity.MaintenanceName,
                    ShopName = entity.ShopName,
                    Price = entity.Price,
                    Notes = entity.Notes
                };
            }
        }

        public bool UpdateVehicleMaintenance(VehicleMaintenanceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .VehicleMaintenanceDbSet
                        .Single(e => e.VehicleMaintenanceId == model.VehicleMaintenanceId);

                entity.VehicleId = model.VehicleId;
                entity.MaintenanceName = model.MaintenanceName;
                entity.ShopName = model.ShopName;
                entity.Price = model.Price;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveVehicleMaintenance(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.VehicleMaintenanceDbSet.Single(e => e.VehicleMaintenanceId == id);

                ctx.VehicleMaintenanceDbSet.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
