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
