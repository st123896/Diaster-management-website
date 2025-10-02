﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using APPR_P_2.Models;

namespace APPR_P_2.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensure database is created
            context.Database.EnsureCreated();

            // Create roles
            string[] roleNames = { "Admin", "Donor", "Volunteer" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create admin user
            var adminUser = await userManager.FindByEmailAsync("admin@disaster.org");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = "admin@disaster.org",
                    Email = "admin@disaster.org",
                    FirstName = "System",
                    LastName = "Administrator",
                    UserRole = "Admin",
                    RegistrationDate = DateTime.Now,
                    EmailConfirmed = true,
                    PhoneNumber = "+1234567890",
                    PhoneNumberConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Create sample donor user
            var donorUser = await userManager.FindByEmailAsync("donor@example.com");
            if (donorUser == null)
            {
                donorUser = new ApplicationUser
                {
                    UserName = "donor@example.com",
                    Email = "donor@example.com",
                    FirstName = "John",
                    LastName = "Donor",
                    UserRole = "Donor",
                    RegistrationDate = DateTime.Now.AddDays(-10),
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(donorUser, "Donor123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(donorUser, "Donor");
                }
            }

            // Create sample volunteer user
            var volunteerUser = await userManager.FindByEmailAsync("volunteer@example.com");
            if (volunteerUser == null)
            {
                volunteerUser = new ApplicationUser
                {
                    UserName = "volunteer@example.com",
                    Email = "volunteer@example.com",
                    FirstName = "Sarah",
                    LastName = "Volunteer",
                    UserRole = "Volunteer",
                    RegistrationDate = DateTime.Now.AddDays(-5),
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(volunteerUser, "Volunteer123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(volunteerUser, "Volunteer");
                }
            }

            // Wait for users to be created
            await context.SaveChangesAsync();

            // Refresh user objects to get their IDs
            adminUser = await userManager.FindByEmailAsync("admin@disaster.org");
            donorUser = await userManager.FindByEmailAsync("donor@example.com");
            volunteerUser = await userManager.FindByEmailAsync("volunteer@example.com");

            // Seed donations if none exist
            if (!context.Donations.Any())
            {
                context.Donations.AddRange(
                    new Donation
                    {
                        DonorId = adminUser.Id,
                        DonationType = "financial",
                        Amount = 100.00m,
                        PaymentMethod = "Credit Card",
                        DonationDate = DateTime.Now.AddDays(-5),
                        IsAnonymous = false,
                        Status = "Completed",
                        AdditionalSupplies = "" // Explicitly set to empty string
                    },
                    new Donation
                    {
                        DonorId = donorUser.Id,
                        DonationType = "supplies",
                        Supplies = new List<string> { "water", "food", "blankets" },
                        DonationDate = DateTime.Now.AddDays(-3),
                        IsAnonymous = true,
                        Status = "Completed",
                        AdditionalSupplies = "Emergency food packages and water bottles"
                    },
                    new Donation
                    {
                        DonorId = donorUser.Id,
                        DonationType = "financial",
                        Amount = 250.00m,
                        PaymentMethod = "PayPal",
                        DonationDate = DateTime.Now.AddDays(-1),
                        IsAnonymous = false,
                        Status = "Completed",
                        AdditionalSupplies = "" // Explicitly set to empty string
                    }
                );
            }

            // Seed volunteer profiles if none exist
            if (!context.VolunteerProfiles.Any())
            {
                context.VolunteerProfiles.AddRange(
                    new VolunteerProfile
                    {
                        UserId = volunteerUser.Id,
                        Skills = new List<string> { "Medical", "First Aid", "Logistics" },
                        Availability = "Weekends",
                        Experience = "2 years in community service",
                        EmergencyResponse = true,
                        Status = "Active"
                    },
                    new VolunteerProfile
                    {
                        UserId = adminUser.Id,
                        Skills = new List<string> { "Coordination", "Management" },
                        Availability = "Flexible",
                        Experience = "5 years in disaster management",
                        EmergencyResponse = true,
                        Status = "Active"
                    }
                );
            }

            // Seed incident reports if none exist
            if (!context.IncidentReports.Any())
            {
                context.IncidentReports.AddRange(
                    new IncidentReport
                    {
                        UserId = adminUser.Id,
                        IncidentType = "Flood",
                        Title = "Major Flooding in Downtown Area",
                        Description = "Severe flooding affecting residential areas and main roads",
                        Location = "Downtown City Center",
                        Severity = "High",
                        ReportedDate = DateTime.Now.AddDays(-2),
                        PhoneNumber = "+1234567890",
                        Status = "Under Review"
                    },
                    new IncidentReport
                    {
                        UserId = donorUser.Id,
                        IncidentType = "Wildfire",
                        Title = "Forest Fire Spreading Rapidly",
                        Description = "Wildfire spreading towards residential areas in the northern region",
                        Location = "Northern Forest Reserve",
                        Severity = "Critical",
                        ReportedDate = DateTime.Now.AddDays(-1),
                        PhoneNumber = "+1234567891",
                        Status = "Emergency"
                    }
                );
            }

            await context.SaveChangesAsync();
        }
    }
}