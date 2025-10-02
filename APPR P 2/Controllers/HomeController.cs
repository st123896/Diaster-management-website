using APPR_P_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace APPR_P_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
      
            // GET: Home/Index
            public ActionResult Index()
            {
                return View();
            }

            // GET: Home/ReportIncident
            public ActionResult ReportIncident()
            {
                // Populate dropdown lists
                ViewBag.IncidentTypes = new[]
                {
                new SelectListItem { Value = "Flood", Text = "Flood" },
                new SelectListItem { Value = "Wildfire", Text = "Wildfire" },
                new SelectListItem { Value = "Earthquake", Text = "Earthquake" },
                new SelectListItem { Value = "Hurricane", Text = "Hurricane" },
                new SelectListItem { Value = "Tornado", Text = "Tornado" },
                new SelectListItem { Value = "Drought", Text = "Drought" },
                new SelectListItem { Value = "Other", Text = "Other" }
            };

                ViewBag.SeverityLevels = new[]
                {
                new SelectListItem { Value = "Low", Text = "Low" },
                new SelectListItem { Value = "Medium", Text = "Medium" },
                new SelectListItem { Value = "High", Text = "High" },
                new SelectListItem { Value = "Critical", Text = "Critical" }
            };

                return View();
            }

            // POST: Home/ReportIncident
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult ReportIncident(IncidentReportViewModel model)
            {
                if (ModelState.IsValid)
                {
                    // Incident reporting logic would go here
                    // For prototype, we'll just redirect to home with a success message
                    TempData["SuccessMessage"] = "Incident reported successfully. Our team will review it shortly.";
                    return RedirectToAction("Index");
                }

                // Repopulate dropdown lists if validation fails
                ViewBag.IncidentTypes = new[]
                {
                new SelectListItem { Value = "Flood", Text = "Flood" },
                new SelectListItem { Value = "Wildfire", Text = "Wildfire" },
                new SelectListItem { Value = "Earthquake", Text = "Earthquake" },
                new SelectListItem { Value = "Hurricane", Text = "Hurricane" },
                new SelectListItem { Value = "Tornado", Text = "Tornado" },
                new SelectListItem { Value = "Drought", Text = "Drought" },
                new SelectListItem { Value = "Other", Text = "Other" }
            };

                ViewBag.SeverityLevels = new[]
                {
                new SelectListItem { Value = "Low", Text = "Low" },
                new SelectListItem { Value = "Medium", Text = "Medium" },
                new SelectListItem { Value = "High", Text = "High" },
                new SelectListItem { Value = "Critical", Text = "Critical" }
            };

                return View(model);
            }

            // GET: Home/Donate
            public ActionResult Donate()
            {
                return View();
            }

            // GET: Home/Volunteer
            public ActionResult Volunteer()
            {
                return View();
            }

            // GET: Home/About
            public ActionResult About()
            {
                return View();
            }

            // GET: Home/ReportIncident
            public ActionResult Incidents()
            {
                return View();
            }
        }
    }