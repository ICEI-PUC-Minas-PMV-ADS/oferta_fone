using OfertaFone.WebUI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.ViewModels.Carrinho
{
    public class IndexViewModel
    {
        public decimal Total { get; set; }
        public int QuantidadeItens { get; set; }
        public List<Vitrine.DetailsViewModel> Produtos { get; set; }
    }
}
