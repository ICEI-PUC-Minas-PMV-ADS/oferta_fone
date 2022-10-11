using OfertaFone.WebUI.ViewModels.Base;

namespace OfertaFone.WebUI.ViewModels.Produto
{
    public class CreateViewModel : BaseViewModel
    {
        public string Nome { get; set; }

        public double Preco { get; set; }

        public string Email { get; set; }
    }
}
