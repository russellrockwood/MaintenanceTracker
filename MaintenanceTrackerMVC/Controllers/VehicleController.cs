using MaintenanceTracker.Models;
using MaintenanceTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintenanceTrackerMVC.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index()
        {
            var service = new VehicleService();
            var model = service.GetVehicles();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new VehicleService();
            if (service.CreateVehicle(model))
            {
                TempData["SaveResult"] = "Vehicle Succesfully Added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Vehicle could not be created");

            return View(model);
        }
    }
}