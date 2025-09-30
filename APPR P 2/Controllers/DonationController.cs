using APPR_P_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APPR_P_2.Controllers
{
    public class DonationController : Controller
    {
        // GET: Donation/Donate
        public ActionResult Donate()
        {
            // Populate dropdown lists
            ViewBag.DonationTypes = new[]
            {
                new SelectListItem { Value = "financial", Text = "Financial Donation" },
                new SelectListItem { Value = "supplies", Text = "Supplies Donation" },
                new SelectListItem { Value = "both", Text = "Both Financial and Supplies" }
            };

            ViewBag.PaymentMethods = new[]
            {
                new SelectListItem { Value = "creditcard", Text = "Credit Card" },
                new SelectListItem { Value = "paypal", Text = "PayPal" },
                new SelectListItem { Value = "banktransfer", Text = "Bank Transfer" }
            };

            ViewBag.SupplyItems = new[]
            {
                new SelectListItem { Value = "water", Text = "Bottled Water" },
                new SelectListItem { Value = "food", Text = "Non-perishable Food" },
                new SelectListItem { Value = "blankets", Text = "Blankets" },
                new SelectListItem { Value = "meds", Text = "Medical Supplies" },
                new SelectListItem { Value = "hygiene", Text = "Hygiene Kits" },
                new SelectListItem { Value = "clothing", Text = "Clothing" }
            };

            return View();
        }

        // POST: Donation/ProcessDonation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessDonation(DonationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Process donation logic would go here
                // For prototype, we'll just redirect to a thank you page
                return RedirectToAction("ThankYou", new { id = Guid.NewGuid() });
            }

            // Repopulate dropdown lists if validation fails
            ViewBag.DonationTypes = new[]
            {
                new SelectListItem { Value = "financial", Text = "Financial Donation" },
                new SelectListItem { Value = "supplies", Text = "Supplies Donation" },
                new SelectListItem { Value = "both", Text = "Both Financial and Supplies" }
            };

            ViewBag.PaymentMethods = new[]
            {
                new SelectListItem { Value = "creditcard", Text = "Credit Card" },
                new SelectListItem { Value = "paypal", Text = "PayPal" },
                new SelectListItem { Value = "banktransfer", Text = "Bank Transfer" }
            };

            ViewBag.SupplyItems = new[]
            {
                new SelectListItem { Value = "water", Text = "Bottled Water" },
                new SelectListItem { Value = "food", Text = "Non-perishable Food" },
                new SelectListItem { Value = "blankets", Text = "Blankets" },
                new SelectListItem { Value = "meds", Text = "Medical Supplies" },
                new SelectListItem { Value = "hygiene", Text = "Hygiene Kits" },
                new SelectListItem { Value = "clothing", Text = "Clothing" }
            };

            return View("Donate", model);
        }

        // GET: Donation/ThankYou
        public ActionResult ThankYou(Guid id)
        {
            ViewBag.DonationId = id;
            return View();
        }
    }
}