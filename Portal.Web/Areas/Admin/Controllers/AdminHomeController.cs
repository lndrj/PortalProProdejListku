using System;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;

namespace Portal.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        public IActionResult IndexAdmin()
        {
            return View();
        }
    }
}

