using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Identity.Enums;

namespace Portal.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class OrderItemController : Controller
    {
        IOrderItemService _orderItemService;
        IAkceAdminService _akceService;
        IOrderService _orderService;
        public OrderItemController(IOrderItemService orderItemService, IAkceAdminService akceService, IOrderService orderService)
        {
            _orderItemService = orderItemService;
            _akceService = akceService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            IList<OrderItem> orderItems = _orderItemService.Select();
            return View(orderItems);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SetOrderAndAkceSelectLists();
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _orderItemService.Create(orderItem);
                return RedirectToAction(nameof(OrderItemController.Index));
            }
            else
            {
                SetOrderAndAkceSelectLists();
                return View(orderItem);
            }
        }

        void SetOrderAndAkceSelectLists()
        {
            IList<Akce> akces = _akceService.Select();
            ViewData[nameof(OrderItem.AkceID)] = new SelectList(akces, nameof(Akce.Id), nameof(Akce.Name));

            IList<Order> orders = _orderService.Select();
            ViewData[nameof(OrderItem.OrderID)] = new SelectList(orders, nameof(Order.Id), nameof(Order.OrderNumber));
        }
    }
}