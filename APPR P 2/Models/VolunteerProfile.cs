using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APPR_P_2.Models
{
    public class VolunteerProfile
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Skills")]
        public List<string> Skills { get; set; } = new List<string>();

        [Required]
        [Display(Name = "Availability")]
        public string Availability { get; set; }

        [Display(Name = "Experience")]
        public string Experience { get; set; } = string.Empty; // Default to empty string

        [Display(Name = "Emergency Response")]
        public bool EmergencyResponse { get; set; }

        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        [Display(Name = "Status")]
        public string Status { get; set; } = "Active";
    }
}