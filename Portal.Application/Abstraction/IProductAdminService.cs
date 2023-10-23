using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Domain.Entities;

namespace Portal.Application.Abstraction
{
    public interface IProductAdminService
    {
        IList<Product> Select();
        void Create(Product product);
        bool Delete(int id);
    }
}
