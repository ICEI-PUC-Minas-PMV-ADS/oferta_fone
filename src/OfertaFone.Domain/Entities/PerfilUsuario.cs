using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfertaFone.Domain.Entities
{
    public class PerfilUsuario : Entity
    {
        public string Nome { get; set; }
        public int? Situacao { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<MapPerfilUsuariosAcessos> MapPerfilUsuariosAcessos { get; set; }
    }
}
