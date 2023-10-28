using System;
using Portal.Application.ViewModels;

namespace Portal.Application.Abstraction
{
	public interface IHomeService
	{
		CarouselProductViewModel GetHomeIndexViewModel();
	}
}

