using System;
using Portal.Domain.Entities;

namespace Portal.Application.ViewModels
{
	public class CarouselProductViewModel
	{
		public IList<Product> Products { get; set; }
		public IList<Carousel> Carousels { get; set; }
	}
}

