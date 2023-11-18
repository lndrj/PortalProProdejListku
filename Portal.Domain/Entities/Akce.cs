using System;
using System.Collections.Generic;
<<<<<<< Updated upstream
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> Stashed changes
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class Akce : Entity<int>
    {
<<<<<<< Updated upstream
        public string Name { get; set; }
        public string Description { get; set; }
=======
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }
        
        [Range(0, double.MaxValue)]
>>>>>>> Stashed changes
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public string ImageSrc { get; set; }
    }
}
