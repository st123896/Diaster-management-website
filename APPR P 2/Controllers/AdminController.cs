using APPR_P_2.Data;
using APPR_P_2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace APPR_P_2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Admin/Index
        public async Task<IActionResult> Index()
        {
            var dashboardStats = new AdminDashboardViewModel
            {
                TotalUsers = await _context.Users.CountAsync(),
                TotalDonations = await _context.Donations.CountAsync(),
                TotalVolunteers = await _context.VolunteerProfiles.CountAsync(),
                TotalIncidents = await _context.IncidentReports.CountAsync(),
                RecentUsers = await _context.Users.OrderByDescending(u => u.RegistrationDate).Take(5).ToListAsync(),
                RecentDonations = await _context.Donations
                    .Include(d => d.Donor)
                    .OrderByDescending(d => d.DonationDate)
                    .Take(5)
                    .ToListAsync()
            };

            return View(dashboardStats);
        }

        // GET: Admin/Users
        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        // GET: Admin/Donations
        public async Task<IActionResult> Donations()
        {
            var donations = await _context.Donations
                .Include(d => d.Donor)
                .OrderByDescending(d => d.DonationDate)
                .ToListAsync();
            return View(donations);
        }

        // GET: Admin/Volunteers
        public async Task<IActionResult> Volunteers()
        {
            var volunteers = await _context.VolunteerProfiles
                .Include(v => v.User)
                .OrderByDescending(v => v.RegistrationDate)
                .ToListAsync();
            return View(volunteers);
        }

        // GET: Admin/Incidents
        public async Task<IActionResult> Incidents()
        {
            var incidents = await _context.IncidentReports
                .Include(i => i.User)
                .OrderByDescending(i => i.CreatedDate)
                .ToListAsync();
            return View(incidents);
        }

        // POST: Admin/UpdateUserRole
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUserRole(string userId, string newRole)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.UserRole = newRole;
                await _userManager.UpdateAsync(user);
                TempData["SuccessMessage"] = $"User role updated to {newRole} successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "User not found.";
            }
            return RedirectToAction("Users");
        }

        // POST: Admin/DeleteUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null && user.UserName != "admin@disaster.org") // Prevent deleting admin
            {
                await _userManager.DeleteAsync(user);
                TempData["SuccessMessage"] = "User deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Cannot delete this user.";
            }
            return RedirectToAction("Users");
        }
    }
}
