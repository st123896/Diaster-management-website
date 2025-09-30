using System.ComponentModel.DataAnnotations;

namespace APPR_P_2.Models
{
    public class VolunteerViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [Display(Name = "City, State")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please select at least one skill")]
        [Display(Name = "Skills & Expertise")]
        public List<string> Skills { get; set; }

        [Required(ErrorMessage = "Please select your availability")]
        [Display(Name = "Availability")]
        public string Availability { get; set; }

        [Required(ErrorMessage = "Please select an area of interest")]
        [Display(Name = "Area of Interest")]
        public string InterestArea { get; set; }

        [Display(Name = "Previous Experience")]
        public string Experience { get; set; }

        [Display(Name = "Available for emergency response")]
        public bool EmergencyResponse { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the terms and conditions")]
        [Display(Name = "I agree to the terms and conditions")]
        public bool Agreement { get; set; }
    }
}