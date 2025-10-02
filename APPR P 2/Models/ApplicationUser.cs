using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace APPR_P_2.Models
{
    public class ApplicationUser : IdentityUser
    {
     
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "Registration Date")]
            public DateTime RegistrationDate { get; set; } = DateTime.Now;

            [Display(Name = "User Role")]
            public string UserRole { get; set; } = "Donor";

            // Navigation properties
            public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();
            public virtual ICollection<IncidentReport> IncidentReports { get; set; } = new List<IncidentReport>();
            public virtual VolunteerProfile VolunteerProfile { get; set; }

            [Display(Name = "Full Name")]
            public string FullName => $"{FirstName} {LastName}";
        
    }
}
