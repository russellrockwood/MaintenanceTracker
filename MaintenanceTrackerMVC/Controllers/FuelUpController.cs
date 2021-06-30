using MaintenanceTracker.Models.FuelUp;
using MaintenanceTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintenanceTrackerMVC.Controllers
{
    [Authorize]
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

        public ActionResult Details(int id)
        {
            var model = new FuelUpService().GetFuelUpById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = new FuelUpService().GetFuelUpById(id);
            var model =
                new FuelUpEdit
                {
                    VehicleId = detail.VehicleId,
                    Price = detail.Price,
                    Miles = detail.Miles,
                    Gallons = detail.Gallons
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FuelUpEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.FuelUpId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new FuelUpService();

            if (service.UpdateFuelUp(model))
            {
                //TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your FuelUp could not be updated");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            //var model = new FuelUpService().GetFuelUpById(id);
            return View(new FuelUpService().GetFuelUpById(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFuelUp(int id)
        {
            new FuelUpService().RemoveFuelUp(id);
            //TempData["SaveResult"] = "Fuel stop removed";
            return RedirectToAction("Index");
        }
    }
}