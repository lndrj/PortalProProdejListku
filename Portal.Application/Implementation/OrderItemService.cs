using System;
using Microsoft.EntityFrameworkCore;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;

namespace Portal.Application.Implementation
{
    public class OrderItemService : IOrderItemService
    {
        PortalDBContext _portalDbContext;

        public OrderItemService(PortalDBContext portalDbContext)
        {
            _portalDbContext = portalDbContext;
        }

        public IList<OrderItem> Select()
        {
            return _portalDbContext.OrderItems
                                  .Include(oi => oi.Akce)
                                  .Include(oi => oi.Order)
                                  .ThenInclude(o => o.User)
                                  .OrderBy(oi => oi.Id)
                                  .ToList();
        }

        public void Create(OrderItem orderItem)
        {
            if (_portalDbContext.OrderItems != null)
            {
                Order? order = _portalDbContext.Orders.FirstOrDefault(o => o.Id == orderItem.OrderID);
                if (order != null)
                {
                    order.TotalPrice += orderItem.Price;
                    _portalDbContext.OrderItems.Add(orderItem);
                    _portalDbContext.SaveChanges();
                }
            }
        }

    }
}

