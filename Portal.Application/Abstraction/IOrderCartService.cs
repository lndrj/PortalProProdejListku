using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Portal.Domain.Entities;

namespace Portal.Application.Abstraction
{
    public interface IOrderCartService
    {
        double AddOrderItemsToSession(int? akceId, ISession session);
        bool ApproveOrderInSession(int userId, ISession session);
        public double CalculateTotalPrice(List<OrderItem> orderItems);
        public double RemoveOrderItemFromSession(int? akceId, ISession session);

    }
}
