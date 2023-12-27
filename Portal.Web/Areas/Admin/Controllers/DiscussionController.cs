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
    public class DiscussionController : Controller
        {
            IDiscussionAdminService _discussionAdminService;
            public DiscussionController(IDiscussionAdminService discussionAdminService)
            {
                _discussionAdminService = discussionAdminService;
            }

            public IActionResult Discussion()
            {
                IList<Diskuze> discussions = _discussionAdminService.Select();
                return View(discussions);
            }

            [HttpGet]
            public IActionResult Delete(int Id)
            {
                bool deleted = _discussionAdminService.Delete(Id);

                if (deleted)
                {
                    return RedirectToAction(nameof(DiscussionController.Discussion));
                }
                else
                    return NotFound();
            }
        }
    }
