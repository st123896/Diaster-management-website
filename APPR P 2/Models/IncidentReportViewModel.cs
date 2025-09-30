using System.ComponentModel.DataAnnotations;

namespace APPR_P_2.Models
{
    public class IncidentReportViewModel
    {
        [Required(ErrorMessage = "Incident type is required")]
        [Display(Name = "Incident Type")]
        public string IncidentType { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Severity level is required")]
        public string Severity { get; set; }

        [Required(ErrorMessage = "Reported date is required")]
        [Display(Name = "Reported Date")]
        [DataType(DataType.Date)]
        public DateTime ReportedDate { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
