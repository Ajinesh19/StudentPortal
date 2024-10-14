using Microsoft.AspNetCore.Antiforgery;

using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{
    public class SignUpUserModel
    {

        [Required(ErrorMessage ="Please the Email ")]
        [Display(Name ="Email Address")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please the Password ")]
        [Compare("ConfirmPassword",ErrorMessage ="Password does not match")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Please the ConfirmPassword ")]
        [Display(Name = "ConfirmPassword ")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
        
        }
}
