using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APPR_P_2.Models
{
    public class Donation
    {
        public int Id { get; set; }

        [Required]
        public string DonorId { get; set; }
        public ApplicationUser Donor { get; set; }

        [Required]
        [Display(Name = "Donation Type")]
        public string DonationType { get; set; } // financial, supplies, both

        [Display(Name = "Amount")]
        [Range(0.01, 100000)]
        public decimal? Amount { get; set; }

        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }

        public List<string> Supplies { get; set; } = new List<string>();

        [Display(Name = "Additional Supplies")]
        public string AdditionalSupplies { get; set; } = string.Empty; // Default to empty string

        [Display(Name = "Donation Date")]
        public DateTime DonationDate { get; set; } = DateTime.Now;

        [Display(Name = "Anonymous")]
        public bool IsAnonymous { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "Completed";
    }
}