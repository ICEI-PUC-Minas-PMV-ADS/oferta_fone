using System.Collections.Generic;

namespace OfertaFone.WebUI.ViewModels.Produto
{
    public class IndexViewModel
    {
        public string Marca { get; set; }

        public string Modelo { get; set; }

        public List<CreateViewModel> CreateViewModels { get; set; }
    }
}
