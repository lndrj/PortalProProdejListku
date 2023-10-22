using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Domain.Entities;

namespace Portal.Infrastructure.Database
{
    public class DatabaseFake
    {
        public static List<Product> Products { get; set; }

        static DatabaseFake()
        {
            Products = new List<Product>();
            Products.Add(new Product {
                Id = 1,
                Name = "iPhone",
                Description = "smartphone",
                Price = 15000,
                ImageSrc = ""
            });
            Products.Add(new Product {
                Id = 2,
                Name = "iPhone",
                Description = "smartphone",
                Price = 15000,
                ImageSrc = ""
            });
            Products.Add(new Product {
                Id = 3,
                Name = "iPhone",
                Description = "smartphone",
                Price = 15000,
                ImageSrc = ""
            });
        }
    }
}
