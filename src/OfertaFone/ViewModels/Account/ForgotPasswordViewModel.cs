using OfertaFone.WebUI.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace OfertaFone.WebUI.ViewModels.Account
{
    public class ForgotPasswordViewModel : BaseViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}
