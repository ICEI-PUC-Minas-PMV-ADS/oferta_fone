using OfertaFone.Domain.Interfaces;
using System;

namespace OfertaFone.Domain.Entities
{
    public class Entity : IEntity
    {
        public Entity() { }

        public int Id { get; set; }
        public DateTime CreatedDate { get => DateTime.Now; }
        public DateTime UpdatedDate { get => DateTime.Now; }
    }
}
