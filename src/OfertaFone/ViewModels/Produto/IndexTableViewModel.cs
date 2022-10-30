using OfertaFone.WebUI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.ViewModels.Produto
{
    public class IndexTableViewModel : BaseViewModel
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public bool Ativo { get; set; }
        public string Image { get; set; }
    }
}
