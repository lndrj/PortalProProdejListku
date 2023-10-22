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
    }
}
