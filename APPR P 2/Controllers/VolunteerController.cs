using APPR_P_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APPR_P_2.Controllers
{
    public class VolunteerController : Controller
    {
        // GET: Volunteer/Index
        public ActionResult Index()
        {
            // Populate dropdown lists
            ViewBag.AvailabilityOptions = new[]
            {
                new SelectListItem { Value = "Immediate", Text = "Immediate (within 24-48 hours)" },
                new SelectListItem { Value = "ShortTerm", Text = "Short-term (within 1 week)" },
                new SelectListItem { Value = "LongTerm", Text = "Long-term (flexible)" },
                new SelectListItem { Value = "Remote", Text = "Remote support only" }
            };

            ViewBag.SkillOptions = new[]
            {
                new SelectListItem { Value = "Medical", Text = "Medical/First Aid" },
                new SelectListItem { Value = "Construction", Text = "Construction/Carpentry" },
                new SelectListItem { Value = "Cooking", Text = "Cooking/Food Preparation" },
                new SelectListItem { Value = "Counseling", Text = "Counseling/Mental Health" },
                new SelectListItem { Value = "Logistics", Text = "Logistics/Coordination" },
                new SelectListItem { Value = "Language", Text = "Language Translation" },
                new SelectListItem { Value = "Teaching", Text = "Teaching/Education" },
                new SelectListItem { Value = "Tech", Text = "Technology/IT" },
                new SelectListItem { Value = "Other", Text = "Other" }
            };

            ViewBag.InterestOptions = new[]
            {
                new SelectListItem { Value = "Emergency Response", Text = "Emergency Response" },
                new SelectListItem { Value = "Supply Distribution", Text = "Supply Distribution" },
                new SelectListItem { Value = "Remote Support", Text = "Remote Support" },
                new SelectListItem { Value = "Medical Support", Text = "Medical Support" },
                new SelectListItem { Value = "Rebuilding", Text = "Rebuilding/Construction" },
                new SelectListItem { Value = "Counseling", Text = "Counseling Services" },
                new SelectListItem { Value = "Teaching", Text = "Education/Teaching" },
                new SelectListItem { Value = "Other", Text = "Other" }
            };

            return View();
        }

        // POST: Volunteer/RegisterVolunteer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterVolunteer(VolunteerViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Process volunteer registration logic would go here
                // For prototype, we'll just redirect to a thank you page
                return RedirectToAction("ThankYou", new { id = Guid.NewGuid() });
            }

            // Repopulate dropdown lists if validation fails
            ViewBag.AvailabilityOptions = new[]
            {
                new SelectListItem { Value = "Immediate", Text = "Immediate (within 24-48 hours)" },
                new SelectListItem { Value = "ShortTerm", Text = "Short-term (within 1 week)" },
                new SelectListItem { Value = "LongTerm", Text = "Long-term (flexible)" },
                new SelectListItem { Value = "Remote", Text = "Remote support only" }
            };

            ViewBag.SkillOptions = new[]
            {
                new SelectListItem { Value = "Medical", Text = "Medical/First Aid" },
                new SelectListItem { Value = "Construction", Text = "Construction/Carpentry" },
                new SelectListItem { Value = "Cooking", Text = "Cooking/Food Preparation" },
                new SelectListItem { Value = "Counseling", Text = "Counseling/Mental Health" },
                new SelectListItem { Value = "Logistics", Text = "Logistics/Coordination" },
                new SelectListItem { Value = "Language", Text = "Language Translation" },
                new SelectListItem { Value = "Teaching", Text = "Teaching/Education" },
                new SelectListItem { Value = "Tech", Text = "Technology/IT" },
                new SelectListItem { Value = "Other", Text = "Other" }
            };

            ViewBag.InterestOptions = new[]
            {
                new SelectListItem { Value = "Emergency Response", Text = "Emergency Response" },
                new SelectListItem { Value = "Supply Distribution", Text = "Supply Distribution" },
                new SelectListItem { Value = "Remote Support", Text = "Remote Support" },
                new SelectListItem { Value = "Medical Support", Text = "Medical Support" },
                new SelectListItem { Value = "Rebuilding", Text = "Rebuilding/Construction" },
                new SelectListItem { Value = "Counseling", Text = "Counseling Services" },
                new SelectListItem { Value = "Teaching", Text = "Education/Teaching" },
                new SelectListItem { Value = "Other", Text = "Other" }
            };

            return View("Index", model);
        }

        // GET: Volunteer/ThankYou
        public ActionResult ThankYou(Guid id)
        {
            ViewBag.VolunteerId = id;
            return View();
        }
    }
}