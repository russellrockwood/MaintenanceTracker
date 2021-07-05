using MaintenanceTracker.Models.FuelUp;
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
    public class FuelUpController : Controller
    {
        private FuelUpService CreateFuelUpService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FuelUpService(userId);
            return service;
        }
        // GET: FuelUp
        public ActionResult Index()
        {
            var fuelUps = CreateFuelUpService().GetFuelUps();
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

            var service = CreateFuelUpService();

            if (service.CreateFuelUp(model))
            {
                TempData["SaveResult"] = "Fuel up created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error adding fuel up.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = CreateFuelUpService().GetFuelUpById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = CreateFuelUpService().GetFuelUpById(id);
            var model =
                new FuelUpEdit
                {
                    FuelUpId = detail.FuelUpId,
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

            var service = CreateFuelUpService();

            if (service.UpdateFuelUp(model))
            {
                TempData["SaveResult"] = "Your Fuel Stop Was Updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your FuelUp could not be updated");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = CreateFuelUpService().GetFuelUpById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFuelUp(int id)
        {
            CreateFuelUpService().RemoveFuelUp(id);
            TempData["SaveResult"] = "Fuel stop removed";
            return RedirectToAction("Index");
        }
    }
}