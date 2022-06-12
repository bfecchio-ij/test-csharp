using System;

namespace Candidatos.Domain.Entities
{
    public abstract class EntityBase
    {
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
