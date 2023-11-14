using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class Akce : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public string ImageSrc { get; set; }
    }
}
