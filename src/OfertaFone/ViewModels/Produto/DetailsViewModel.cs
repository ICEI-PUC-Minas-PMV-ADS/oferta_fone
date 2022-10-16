using OfertaFone.WebUI.ViewModels.Base;

namespace OfertaFone.WebUI.ViewModels.Produto
{
    public class DetailsViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public string Image { get; set; }
        public bool Ativo { get; set; }
        public int? UsuarioId { get; set; }
        public string Modelo { get; set; }
        public string Memoria { get; set; }
        public string Camera { get; set; }
        public string Processador { get; set; }
        public string RAM { get; set; }

    }
}
