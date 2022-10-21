using OfertaFone.WebUI.ViewModels.Base;

namespace OfertaFone.WebUI.ViewModels.Vitrine
{
    public class DetailsViewModel : BaseViewModel
    {
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string Image { get; set; }
        public int? UsuarioId { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Memoria { get; set; }
        public string Camera { get; set; }
        public string Processador { get; set; }
        public string RAM { get; set; }

    }
}
