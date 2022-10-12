using System;

namespace OfertaFone.Domain.Entities
{
    public class ProdutoEntity : Entity
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string Image { get; set; }
        public bool Ativo { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Processador { get; set; }
        public string Memoria { get; set; }
        public string Camera { get; set; }
        public string RAM { get; set; }
        public string Detalhes { get; set; }
    }
}
