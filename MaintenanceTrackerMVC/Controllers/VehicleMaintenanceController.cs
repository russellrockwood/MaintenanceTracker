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
        private VehicleMaintenanceService CreateVehicleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VehicleMaintenanceService(userId);
            return service;
        }
        // GET: VehicleMaintenance
        public ActionResult Index()
        {
            var vehicleMaintenanceList = CreateVehicleService().GetVehicleMaintenanceList();
            return View(vehicleMaintenanceList);
        }

        public ActionResult Create()
        {
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

            var service = CreateVehicleService();

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
            var model = CreateVehicleService().GetVehicleMaintenanceById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = CreateVehicleService().GetVehicleMaintenanceById(id);

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

            var service = CreateVehicleService();

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
            var service = CreateVehicleService();
            var model = service.GetVehicleMaintenanceById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVehicleMaintenance(int id)
        {
            CreateVehicleService().RemoveVehicleMaintenance(id);
            TempData["SaveResult"] = "Vehicle Maintenance Item Removed";
            return RedirectToAction("Index");
        }
    }
}