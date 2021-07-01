using MaintenanceTracker.Models.VehicleMaintenance;
using MaintenanceTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintenanceTrackerMVC.Controllers
{
    public class VehicleMaintenanceController : Controller
    {
        [Authorize]
        // GET: VehicleMaintenance
        public ActionResult Index()
        {
            var vehicleMaintenanceList = new VehicleMaintenanceService().GetVehicleMaintenanceList();
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

            var service = new VehicleMaintenanceService();

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
            var model = new VehicleMaintenanceService().GetVehicleMaintenanceById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = new VehicleMaintenanceService().GetVehicleMaintenanceById(id);

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

            var service = new VehicleMaintenanceService();

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
            return View(new VehicleMaintenanceService().GetVehicleMaintenanceById(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVehicleMaintenance(int id)
        {
            new VehicleMaintenanceService().RemoveVehicleMaintenance(id);
            TempData["SaveResult"] = "Vehicle Maintenance Item Removed";
            return RedirectToAction("Index");
        }
    }
}