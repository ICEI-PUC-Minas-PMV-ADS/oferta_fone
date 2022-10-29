using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfertaFone.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string CpfCnpj { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int? PerfilUsuarioId { get; set; }
        public int? Situacao { get; set; }
        public string Image { get; set; }
        public DateTime? DataNascimento { get; set; }
        public PerfilUsuario PerfilUsuario { get; set; }
        public ICollection<ProdutoEntity> ProdutoEntity { get; set; }
    }
}
