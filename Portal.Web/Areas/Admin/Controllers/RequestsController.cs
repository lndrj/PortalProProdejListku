using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Identity.Enums;

namespace Portal.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class RequestsController : Controller
	{
        IRequestsAdminService _requestsAdminService;
        public RequestsController(IRequestsAdminService requestsAdminService)
        {
            _requestsAdminService = requestsAdminService;
        }

        public IActionResult Requests()
        {
            IList<AdminRequest> requests = _requestsAdminService.Select();
            return View(requests);
        }

        
        public IActionResult Delete(int Id)
        {
            bool deleted = _requestsAdminService.Delete(Id);

            if (deleted)
            {
                return RedirectToAction(nameof(RequestsController.Requests));
            }
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            AdminRequest? adminRequest = _requestsAdminService.Select().FirstOrDefault(req => req.Id == id);

            if (adminRequest == null)
            {
                return NotFound();
            }

            return View(adminRequest);
        }

        [HttpPost]
        public IActionResult Edit(AdminRequest adminRequest)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Solved));
            }

            return View(adminRequest);
        }

        [HttpGet]
        public IActionResult Solved(int id)
        {
            AdminRequest? adminRequest = _requestsAdminService.Select().FirstOrDefault(req => req.Id == id);

            if (adminRequest == null)
            {
                return NotFound();
            }

            return View(adminRequest);
        }

        [HttpPost]
        public IActionResult MarkAsSolved(int id)
        {
            // Uloží se stav solved
            _requestsAdminService.Update(id);
            return RedirectToAction(nameof(Requests));
        }

    }
}

