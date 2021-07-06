using MaintenanceTracker.Data;
using MaintenanceTracker.Models.VehicleMaintenance;
using MaintenanceTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintenanceTrackerMVC.Controllers
{
    [Authorize]
    public class VehicleMaintenanceController : Controller
    {
        private VehicleMaintenanceService CreateVehicleMaintenanceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VehicleMaintenanceService(userId);
            return service;
        }

        private VehicleService CreateVehicleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VehicleService(userId);
            return service;
        }

        // GET: VehicleMaintenance
        public ActionResult Index()
        {
            var vehicleMaintenanceList = CreateVehicleMaintenanceService().GetVehicleMaintenanceList();
            return View(vehicleMaintenanceList);
        }

        public ActionResult Create()
        {
            var vehicleService = CreateVehicleService();
            List<Vehicle> Vehicles = vehicleService.GetVehiclesList().ToList();
            ViewBag.VehicleId = Vehicles.Select(v => new SelectListItem()
            {
                Value = v.VehicleId.ToString(),
                Text = v.VehicleModel,
                //Selected = detail.VehicleId == v.VehicleId
            });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleMaintenanceCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateVehicleMaintenanceService();

            if (service.CreateVehicleMaintenance(model))
            {
                TempData["SaveResult"] = "Vehicle Maintenance Added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error Adding Maintenance Item");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = CreateVehicleMaintenanceService().GetVehicleMaintenanceById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = CreateVehicleMaintenanceService().GetVehicleMaintenanceById(id);


            var vehicleService = CreateVehicleService();
            List<Vehicle> Vehicles = vehicleService.GetVehiclesList().ToList();
            ViewBag.VehicleId = Vehicles.Select(v => new SelectListItem()
            {
                Value = v.VehicleId.ToString(),
                Text = v.VehicleModel,
                Selected = detail.VehicleId == v.VehicleId
            });

            var model = new VehicleMaintenanceEdit
            {
                VehicleMaintenanceId = detail.VehicleMaintenanceId,
                VehicleId = detail.VehicleId,
                MaintenanceName = detail.MaintenanceName,
                ShopName = detail.ShopName,
                Price = detail.Price,
                Notes = detail.Notes
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehicleMaintenanceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.VehicleMaintenanceId != id)
            {
                ModelState.AddModelError("", "Id Mistmatch");
                return View(model);
            }

            var service = CreateVehicleMaintenanceService();

            if (service.UpdateVehicleMaintenance(model))
            {
                TempData["SaveResult"] = "Your Maintenance Record Was Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Maintenance Record Could Not Be Updated");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateVehicleMaintenanceService();
            var model = service.GetVehicleMaintenanceById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVehicleMaintenance(int id)
        {
            CreateVehicleMaintenanceService().RemoveVehicleMaintenance(id);
            TempData["SaveResult"] = "Vehicle Maintenance Item Removed";
            return RedirectToAction("Index");
        }
    }
}