using MaintenanceTracker.Models;
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
    public class VehicleController : Controller
    {
        private VehicleService CreateVehicleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VehicleService(userId);
            return service;
        }
        // GET: Vehicle
        public ActionResult Index()
        {
            var service = CreateVehicleService();
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

            var service = CreateVehicleService();
            if (service.CreateVehicle(model))
            {
                TempData["SaveResult"] = "Vehicle Succesfully Added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Vehicle could not be created");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateVehicleService();
            var model = service.GetVehicleById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateVehicleService();
            var detail = service.GetVehicleById(id);
            var model =
                new VehicleEdit
                {
                    VehicleId = detail.VehicleId,
                    Year = detail.Year,
                    Make = detail.Make,
                    VehicleModel = detail.VehicleModel,
                    Displacement = detail.Displacement,
                    IsAutomatic = detail.IsAutomatic,
                    Odometer = detail.Odometer
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehicleEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.VehicleId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateVehicleService();

            if (service.UpdateVehicle(model))
            {
                TempData["SaveResult"] = "Vehicle information updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateVehicleService();
            var model = service.GetVehicleById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateVehicleService();
            service.DeleteVehicle(id);

            TempData["SaveResult"] = "Vehicle deleted";
            
            return RedirectToAction("Index");
        }

        public ActionResult GetFuelUpRecord(int id)
        {
            var service = CreateVehicleService();
            var model = service.GetFuelUpHistory(id);

            ViewBag.VehicleId = id;
            return View(model);
        }
        
        public ActionResult GetMaintenanceRecord(int id)
        {
            var service = CreateVehicleService();
            var model = service.GetMaintenanceHistory(id);

            ViewBag.VehicleId = id;

            return View(model);
        }
    }
}