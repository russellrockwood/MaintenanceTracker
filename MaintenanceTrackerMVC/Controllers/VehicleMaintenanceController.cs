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
                TempData["SaveResult"] = "Vehicle Maintenance record created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error adding maintenance record");
            return View(model);
        }
    }
}