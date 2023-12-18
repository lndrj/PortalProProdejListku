using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class OrderItem : Entity<int>
    {
        public int OrderID { get; set; }

        [ForeignKey(nameof(Akce))]
        public int AkceID { get; set; }

        [Required]
        public int Amount { get; set; }
        [Required]
        public double Price { get; set; }

        public Order? Order { get; set; }
        public Akce? Akce { get; set; }
    }
}
