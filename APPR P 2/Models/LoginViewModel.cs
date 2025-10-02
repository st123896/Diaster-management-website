using System.ComponentModel.DataAnnotations;

namespace APPR_P_2.Models
{
    public class LoginViewModel
    {
       
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        
    }
}
