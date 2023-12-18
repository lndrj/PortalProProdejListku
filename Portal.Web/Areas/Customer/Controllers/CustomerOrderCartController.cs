using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Identity;
using Portal.Infrastructure.Identity.Enums;
using Portal.Web.Controllers;

namespace Portal.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = nameof(Roles.Customer))]
    public class CustomerOrderCartController : Controller
    {
        const string totalPriceString = "TotalPrice";
        const string orderItemsString = "OrderItems";


        ISecurityService secureService;
        IOrderCartService orderCartService;

        public CustomerOrderCartController(ISecurityService iSecure, IOrderCartService orderCartService)
        {
            this.secureService = iSecure;
            this.orderCartService = orderCartService;
        }


        [HttpPost]
        public double AddOrderItemsToSession(int? akceId)
        {
            if (HttpContext.Session != null && HttpContext.Session.IsAvailable)
            {
                return orderCartService.AddOrderItemsToSession(akceId, this.HttpContext.Session);
            }

            return 0;
        }


        public async Task<IActionResult> ApproveOrderInSession()
        {
            if (HttpContext.Session != null && HttpContext.Session.IsAvailable)
            {
                User currentUser = await secureService.GetCurrentUser(User);

                if (orderCartService.ApproveOrderInSession(currentUser.Id, HttpContext.Session) == true)
                {
                    return RedirectToAction(nameof(CustomerOrdersController.Index), nameof(CustomerOrdersController).Replace(nameof(Controller), String.Empty), new { Area = nameof(Customer) });
                }
            }

            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace(nameof(Controller), String.Empty), new { Area = String.Empty });

        }
    }
}
