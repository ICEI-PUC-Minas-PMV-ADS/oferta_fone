using OfertaFone.WebUI.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace OfertaFone.WebUI.ViewModels.Produto
{
    public class CreateViewModel : BaseViewModel
    {
        [Required]
        public string Nome { get; set; }

        public double Preco { get; set; }

        public string Email { get; set; }
    }
}
