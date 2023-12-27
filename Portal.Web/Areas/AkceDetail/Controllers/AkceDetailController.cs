using Microsoft.AspNetCore.Mvc;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;

namespace Portal.Web.Areas.AkceDetail.Controllers
{
	[Area("AkceDetail")]
	public class AkceDetailController : Controller
	{
		public readonly PortalDBContext _portalDbContext;

		public AkceDetailController(PortalDBContext portalDbContext)
		{
			_portalDbContext = portalDbContext;
		}

		public IActionResult Detail(int id)
		{
			Akce detail = _portalDbContext.Akces.FirstOrDefault(a => a.Id == id);

			if (detail == null)
			{
				return NotFound();
			}

			return View(detail);
		}
	}
}
