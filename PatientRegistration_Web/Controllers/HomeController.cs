using PatientRegistration_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientRegistration_Web.Controllers
{
    public class HomeController : Controller
    {
        private PatientDbEntities dbContext = new PatientDbEntities();
        public ActionResult Index()
        {
            return View(dbContext.PatientTbls.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}