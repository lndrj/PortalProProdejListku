using System;
using Portal.Application.Abstraction;
using Portal.Application.ViewModels;
using Portal.Infrastructure.Database;

namespace Portal.Application.Implementation
{
	public class HomeService : IHomeService
	{
		public CarouselProductViewModel GetHomeIndexViewModel()
		{
			CarouselProductViewModel viewModel = new CarouselProductViewModel();
			viewModel.Akces = DatabaseFake.Akces;
			viewModel.Carousels = DatabaseFake.Carousels;
			return viewModel;
		}
	}
}

