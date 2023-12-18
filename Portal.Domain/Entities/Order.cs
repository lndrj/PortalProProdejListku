using Portal.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class Order : Entity<int>
    {
        public DateTime DateTimeCreated { get; set; }

        [Required]
        public string OrderNumber { get; set; }
        
        [Required]
        public double TotalPrice { get; set; }
        
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public IUser User { get; set; }

        public IList<OrderItem> OrderItems { get; set; }
    }
}
