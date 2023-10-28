using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;

namespace Portal.Application.Implementation
{
    public class ProductAdminDFService : IProductAdminService
    {
        public IList<Product> Select()
        {
            return DatabaseFake.Products;
        }

        public void Create(Product product)
        {
            if (DatabaseFake.Products != null && DatabaseFake.Products.Count > 0)
            {
                product.Id = DatabaseFake.Products.Last().Id + 1;
            }
            else
                product.Id = 1;

            if (DatabaseFake.Products != null)
                DatabaseFake.Products.Add(product);
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Product? product = DatabaseFake.Products.FirstOrDefault(prod => prod.Id == id);

            if(product != null)
            {
                deleted = DatabaseFake.Products.Remove(product);
            }

            return deleted;
        }

        public void Update(Product product)
        {
            Product? aktualizovanyProdukt = DatabaseFake.Products.FirstOrDefault(p => p.Id == product.Id);
            if (aktualizovanyProdukt != null)
            {
                aktualizovanyProdukt.Name = product.Name;
                aktualizovanyProdukt.Description = product.Description;
                aktualizovanyProdukt.Price = product.Price;
                aktualizovanyProdukt.ImageSrc = product.ImageSrc;       
            }

        }
    }
}
