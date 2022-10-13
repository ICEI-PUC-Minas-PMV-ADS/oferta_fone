using OfertaFone.WebUI.ViewModels.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OfertaFone.WebUI.ViewModels.Produto
{
    public class IndexViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
    }
}