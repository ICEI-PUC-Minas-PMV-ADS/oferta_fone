using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfertaFone.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string CpfCnpj { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public int? PerfilUsuarioId { get; private set; }
        public int? Situacao { get; private set; }
        public PerfilUsuario PerfilUsuario { get; set; }
    }
}
