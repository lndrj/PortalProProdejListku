using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Identity;
using Portal.Infrastructure.Identity.Enums;

namespace Portal.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = nameof(Roles.Customer))]
    public class CustomerOrdersController : Controller
    {

        ISecurityService iSecure;
        IOrderCustomerService orderCustomerService;

        public CustomerOrdersController(ISecurityService iSecure, IOrderCustomerService orderCustomerService)
        {
            this.iSecure = iSecure;
            this.orderCustomerService = orderCustomerService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                User currentUser = await iSecure.GetCurrentUser(User);
                if (currentUser != null)
                {
                    IList<Order> userOrders = orderCustomerService.GetOrdersForUser(currentUser.Id);
                    return View(userOrders);
                }
            }

            return NotFound();
        }
    }
}
