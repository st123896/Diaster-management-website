using System.ComponentModel.DataAnnotations;

namespace APPR_P_2.Models
{
    public class DonationViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string DonorFirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string DonorLastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email Address")]
        public string DonorEmail { get; set; }

        [Required(ErrorMessage = "Donation type is required")]
        [Display(Name = "Donation Type")]
        public string DonationType { get; set; } // financial, supplies, both

        [Display(Name = "Donation Amount")]
        [Range(1, 100000, ErrorMessage = "Donation amount must be at least $1")]
        public decimal? DonationAmount { get; set; }

        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; } // creditcard, paypal, banktransfer

        [Display(Name = "Supplies")]
        public List<string> Supplies { get; set; }

        [Display(Name = "Additional Supplies")]
        public string AdditionalSupplies { get; set; }

        [Display(Name = "Donate Anonymously")]
        public bool DonateAnonymously { get; set; }

        [Display(Name = "Subscribe to Newsletter")]
        public bool SubscribeToNewsletter { get; set; } = true;
    }
}