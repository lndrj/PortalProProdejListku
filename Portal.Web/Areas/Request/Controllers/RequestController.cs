using Microsoft.AspNetCore.Mvc;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;

namespace Portal.Web.Areas.Request.Controllers
{
	[Area("Request")]
	public class RequestController : Controller
	{       

		private readonly IRequestsAdminService _requestsAdminService;
		public RequestController(IRequestsAdminService requestsAdminService)
		{
			_requestsAdminService = requestsAdminService;
		}

		public IActionResult Request()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Create()
		{
			var model = new AdminRequest { Solved = false }; 
			return View(model);
		}

		[HttpPost]
		public IActionResult Create(AdminRequest adminRequest)
		{
			if (ModelState.IsValid)
			{
				_requestsAdminService.Create(adminRequest);

				return RedirectToAction("Index", "Home");
			}

			return View(adminRequest);
		}
	}
}
