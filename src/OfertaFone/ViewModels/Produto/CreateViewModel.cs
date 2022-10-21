using OfertaFone.WebUI.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace OfertaFone.WebUI.ViewModels.Produto
{
    public class CreateViewModel : BaseViewModel
    {
        [Required]
        public decimal Preco { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Marca { get; set; }
        public string Processador{ get; set; }
        public string Memoria { get; set; }
        public string Camera { get; set; }
        public string RAM { get; set; }
    }
}