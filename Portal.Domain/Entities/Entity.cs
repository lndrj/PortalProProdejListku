using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public abstract class Entity<T>
    {
        //[Key] atribut, pokud neni zrejmy
        public T Id { get; set; }
    }
}
