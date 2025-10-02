﻿using APPR_P_2.Data;
using APPR_P_2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace APPR_P_2.Controllers
{
  
        public class AccountController : Controller
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly SignInManager<ApplicationUser> _signInManager;

            public AccountController(
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }

            // GET: Account/Login
            [HttpGet]
            [AllowAnonymous]
            public IActionResult Login(string returnUrl = null)
            {
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }

            // POST: Account/Login
            [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
            {
                ViewData["ReturnUrl"] = returnUrl;

                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        var user = await _userManager.FindByEmailAsync(model.Email);
                        if (user != null)
                        {
                            // Check if user is admin
                            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                            if (isAdmin)
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                        }
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }
                }

                return View(model);
            }

            // GET: Account/Register
            [HttpGet]
            [AllowAnonymous]
            public IActionResult Register()
            {
                return View();
            }

            // POST: Account/Register
            [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Register(RegisterViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserRole = "Donor", // Default role
                        RegistrationDate = DateTime.Now
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        // Add to Donor role
                        await _userManager.AddToRoleAsync(user, "Donor");

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                return View(model);
            }

            // POST: Account/Logout
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Logout()
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }

            // GET: Account/AccessDenied
            [HttpGet]
            public IActionResult AccessDenied()
            {
                return View();
            }

            private IActionResult RedirectToLocal(string returnUrl)
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }