using System;

namespace CQRS.INFO.Models.Entities.Core
{
    public class Entity
    {
        public DateTime InsertDate { get; private set; }
        public DateTime? ModifyDate { get; private set; }

        public Entity()
        {
            var date = DateTime.Now;
            InsertDate = date;
            ModifyDate = date;
        }

        //public void Update()
        //{
        //    ModifyDate = DateTime.Now;
        //}
    }
}
