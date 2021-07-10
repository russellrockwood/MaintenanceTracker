using MaintenanceTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintenanceTrackerMVC.Controllers
{
    public class OBDController : Controller
    {
        // GET: OBD
        public ActionResult Index()
        {
            var service = new OBD_Service();
            var model = service.LoadJson();
            return View(model);
        }
    }
}