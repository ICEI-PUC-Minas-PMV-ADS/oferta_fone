using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.ViewModels.Base
{
    public class PedidoBaseViewModel : BaseViewModel
    {
        public decimal Total { get; set; }
        public int QuantidadeItens { get; set; }
        public List<Vitrine.DetailsViewModel> Produtos { get; set; }
    }
}
