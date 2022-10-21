using OfertaFone.WebUI.ViewModels.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OfertaFone.WebUI.ViewModels.Vitrine
{
    public class IndexViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
        public string Image { get; set; }
    }
}