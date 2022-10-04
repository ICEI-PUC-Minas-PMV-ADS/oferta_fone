using OfertaFone.WebUI.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace OfertaFone.WebUI.ViewModels.Account
{
    public class LoginViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
