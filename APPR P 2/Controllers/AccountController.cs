using APPR_P_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace APPR_P_2.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Authentication logic would go here
                // For prototype, we'll just redirect to home
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Registration logic would go here
                // For prototype, we'll just redirect to home
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
