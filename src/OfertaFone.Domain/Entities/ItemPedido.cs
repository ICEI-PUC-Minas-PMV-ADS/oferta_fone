using OfertaFone.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfertaFone.Domain.Entities
{
    public class ItemPedido : Entity
    {
        public int? ProdutoId { get; set; }
        public ProdutoEntity Produto { get; set; }
        public int? PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}
