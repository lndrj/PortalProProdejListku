using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Portal.Application.Abstraction
{
    public interface IOrderCartService
    {
        double AddOrderItemsToSession(int? akceId, ISession session);
        bool ApproveOrderInSession(int userId, ISession session);
    }
}
