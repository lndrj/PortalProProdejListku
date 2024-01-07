using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.ViewModels;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;
using Portal.Infrastructure.Identity;

namespace Portal.Web.Areas.AkceDetail.Controllers
{
	[Area("AkceDetail")]
	public class AkceDetailController : Controller
	{
		public readonly PortalDBContext _portalDbContext;
		public readonly UserManager<User> _userManager;

		public AkceDetailController(PortalDBContext portalDbContext, UserManager<User> userManager)
		{
			_portalDbContext = portalDbContext;
			_userManager = userManager;
		}

        public IActionResult Detail(int id)
        {
            Akce akce = _portalDbContext.Akces.FirstOrDefault(a => a.Id == id);

            if (akce == null)
            {
                return NotFound();
            }

            IList<Diskuze> diskuze = _portalDbContext.Discussions.Where(d => d.AkceID == id).ToList();

            var viewModel = new AkceDetailViewModel
            {
                Akce = akce,
                Diskuze = diskuze
            };

            return View(viewModel);
        }

        [HttpPost]
		[Authorize]
		public async Task<IActionResult> AddComment(AkceDetailViewModel model)
		{
			var uzivatel = await _userManager.GetUserAsync(User);

            if (uzivatel == null)
            {
                return RedirectToAction("Login", "Account");
            }

            Akce akce = _portalDbContext.Akces.FirstOrDefault(a => a.Id == model.Akce.Id);

			if(akce == null)
			{
				return NotFound();
			}

			Diskuze novyPrispevek = new Diskuze
			{
				AkceID = model.Akce.Id,
				UserID = uzivatel.Id,
				Komentar = model.NewComment
			};

			_portalDbContext.Discussions.Add(novyPrispevek);
			_portalDbContext.SaveChanges();

			return RedirectToAction("Detail", new { id = model.Akce.Id });
		}
	}
}
