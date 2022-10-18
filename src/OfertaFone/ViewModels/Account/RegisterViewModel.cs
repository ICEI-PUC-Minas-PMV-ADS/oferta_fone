using OfertaFone.WebUI.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace OfertaFone.WebUI.ViewModels.Account
{
    public class RegisterViewModel : BaseViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public bool Enabled { get; set; }
        public int? PerfilUsuarioId { get; set; }
    }
}
