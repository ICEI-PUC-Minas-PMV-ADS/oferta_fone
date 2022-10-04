using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfertaFone.Domain.Entities
{
    public class MapPerfilUsuariosAcessos : Entity
    {
        public int? PerfilUsuarioId { get; set; }
        public int? AcessoId { get; set; }
        public PerfilUsuario PerfilUsuario { get; set; }
        public Acesso Acesso { get; set; }
    }
}
