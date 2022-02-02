using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public string ReturnUrl { get; set; }
    }
}