using PatientRegistration_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PatientRegistration_Web.Controllers
{
    public class HomeController : Controller
    {
        private PatientDbEntities dbContext = new PatientDbEntities();

        public ActionResult Index(string search)
        {
            List<PatientTbl> patientList = dbContext.PatientTbls.ToList();

            if (!String.IsNullOrEmpty(search))
            {
                patientList = patientList.Where(s => Convert.ToString(s.MRN).Contains(search)).ToList();
            }

            return View(patientList);
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