using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portal.Application.Abstraction;
using Portal.Application.ViewModels;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;
using System.Drawing.Printing;

namespace Portal.Web.Areas.AkcePrehled.Controllers
{
    [Area("AkcePrehled")]
    public class AkcePrehledController : Controller
    {
        private readonly PortalDBContext _portalDbContext;
        private readonly IAkceAdminService _akceAdminService;


		public AkcePrehledController(PortalDBContext portalDbContext, IAkceAdminService akceAdminService)
		{
			_portalDbContext = portalDbContext;
			_akceAdminService = akceAdminService;
		}

		public IActionResult AkceList(string searchTerm, DateTime? dateFilter, double? minPriceFilter, double? maxPriceFilter, int page = 1, int pageSize = 10)
		{
			var akceList = _portalDbContext.Akces.AsQueryable();

			// Filtry 
			if (!string.IsNullOrEmpty(searchTerm))
			{
				akceList = akceList.Where(a => a.Name.Contains(searchTerm));
			}
			if (dateFilter.HasValue)
			{
				akceList = akceList.Where(a => a.Date.Date == dateFilter.Value.Date);
			}

			if (minPriceFilter.HasValue)
			{
				akceList = akceList.Where(a => a.Price >= minPriceFilter.Value);
			}

			if (maxPriceFilter.HasValue)
			{
				akceList = akceList.Where(a => a.Price <= maxPriceFilter.Value);
			}
			
			int totalItems = akceList.Count();
			var paginatedList = akceList.Skip((page - 1) * pageSize).Take(pageSize).ToList();


			var viewModel = new AkceListViewModel
			{
				AkceList = akceList.ToList(),
				Search = searchTerm,
				DateFilter = dateFilter,
				MinPriceFilter = minPriceFilter,
				MaxPriceFilter = maxPriceFilter,
				Page = page,
				PageSize = pageSize,
				TotalItems = totalItems
			};

			return View(viewModel);
		}

	}
}
