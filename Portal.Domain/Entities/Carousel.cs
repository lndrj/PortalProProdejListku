using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class Carousel : Entity<int>
    {
        [Required]
        //Prebije nullable warning
        public string? ImageSrc { get; set; }
        public string? ImageAlt { get; set; }
    }
}
