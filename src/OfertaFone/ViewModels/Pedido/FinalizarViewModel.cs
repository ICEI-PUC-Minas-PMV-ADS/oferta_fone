using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.ViewModels.Pedido
{
    public class FinalizarViewModel
    {
        [Required]
        public string CVV { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 18)]
        [DataType(DataType.CreditCard)]
        public string Numero_Cartao { get; set; }
        [Required]
        public string Data_Expiracao { get; set; }
    }
}
