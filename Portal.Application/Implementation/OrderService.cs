using System;
using Microsoft.EntityFrameworkCore;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;

namespace Portal.Application.Implementation
{
    public class OrderService : IOrderService
    {
        PortalDBContext _portalDbContext;

        public OrderService(PortalDBContext portalDbContext)
        {
            _portalDbContext = portalDbContext;
        }

        public IList<Order> Select()
        {
            return _portalDbContext.Orders
                                  .Include(oi => oi.User)
                                  .ToList();
        }
    }
}

