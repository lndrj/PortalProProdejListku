using System;
using Microsoft.EntityFrameworkCore;
using Portal.Infrastructure.Database;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;


namespace Portal.Application.Implementation
{
    public class OrderCustomerService : IOrderCustomerService
    {
        PortalDBContext _portalDbContext;

        public OrderCustomerService(PortalDBContext portalDbContext)
        {
            _portalDbContext = portalDbContext;
        }

        public IList<Order> GetOrdersForUser(int userId)
        {
            return _portalDbContext.Orders.Where(or => or.UserId == userId)
                                         .Include(o => o.User)
                                         .Include(o => o.OrderItems)
                                         .ThenInclude(oi => oi.Akce)
                                         .ToList();
        }
    }
}

