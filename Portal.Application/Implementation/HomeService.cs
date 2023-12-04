using System;
using Portal.Application.Abstraction;
using Portal.Application.ViewModels;
using Portal.Infrastructure.Database;

namespace Portal.Application.Implementation
{
	public class HomeService : IHomeService
	{
		PortalDBContext _portalDbContext;
		public HomeService(PortalDBContext portalDbContext)
		{
			_portalDbContext = portalDbContext;
		}
		public CarouselProductViewModel GetHomeIndexViewModel()
		{
			CarouselProductViewModel viewModel = new CarouselProductViewModel();
			viewModel.Akces = _portalDbContext.Akces.ToList();
			viewModel.Carousels = _portalDbContext.Carousels.ToList();
			return viewModel;
		}
	}
}

