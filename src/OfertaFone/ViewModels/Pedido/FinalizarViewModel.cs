using OfertaFone.WebUI.Tipo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.ViewModels.Pedido
{
    public class FinalizarViewModel : IValidatableObject
    {
        public string CVV { get; set; }
        [StringLength(20, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 18)]
        [DataType(DataType.CreditCard)]
        public string Numero_Cartao { get; set; }
        public string Data_Expiracao { get; set; }
        [Required]
        public string? TipoPagamento { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            bool existePropriedadeNulas = typeof(FinalizarViewModel).GetProperties().Any(a => a.GetValue(this) == null);

            // Verifica se as propriedades da classe foram preenchidas corretamente, caso a forma de pagamento seja cartão de crédito.
            if (TipoFormaPagamento.CARTAO_CREDITO.Equals(TipoPagamento) && existePropriedadeNulas)
            {
                results.Add(new ValidationResult("Preencha os valores corretamtente.", new string[] { nameof(TipoPagamento) }));
            }

            return results;
        }
    }
}
