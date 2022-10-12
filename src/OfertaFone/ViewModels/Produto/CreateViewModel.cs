using OfertaFone.WebUI.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace OfertaFone.WebUI.ViewModels.Produto
{
    public class CreateViewModel : BaseViewModel
    {
        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        public string Processador{ get; set; }

        public string Memoria { get; set; }

        public string Camera { get; set; }

        public string RAM { get; set; }

        [Required]
        public decimal Preco { get; set; }
        public string Detalhes { get; set; }

        public string Imagem { get; set; }
        public string Nome { get; set; }
    }
}