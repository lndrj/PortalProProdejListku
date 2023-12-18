using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Abstraction
{
    public interface IOrderItemService
    {
        IList<OrderItem> Select();
        void Create(OrderItem orderItem);
    }
}
