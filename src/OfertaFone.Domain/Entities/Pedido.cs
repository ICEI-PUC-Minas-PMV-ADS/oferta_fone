using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfertaFone.Domain.Entities
{
    public class Pedido : Entity
    {
        public decimal Total { get; set; }
        public bool Status { get; set; }
        public int QuantidadeItens { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<ItemPedido> ItemPedido { get; set; }
    }
}
