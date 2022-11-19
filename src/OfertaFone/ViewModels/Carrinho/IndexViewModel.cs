using OfertaFone.WebUI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.ViewModels.Carrinho
{
    public class IndexViewModel : PedidoBaseViewModel
    {
        [Required]
        public int? CVV { get; set; }
        [Required]
        public int? Numero_Cartao { get; set; }
        [Required]
        public string? Data_Expiracao { get; set; }
    }
}
