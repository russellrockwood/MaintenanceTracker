using MaintenanceTracker.Models.FuelUp;
using MaintenanceTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintenanceTrackerMVC.Controllers
{
    public class FuelUpController : Controller
    {
        // GET: FuelUp
        public ActionResult Index()
        {
            var fuelUps = new FuelUpService().GetFuelUps();
            return View(fuelUps);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FuelUpCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = new FuelUpService();

            if (service.CreateFuelUp(model))
            {
                //TempData["SaveResult"] = "Fuel up created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error adding fuel up.");
            return View(model);
        }
    }
}