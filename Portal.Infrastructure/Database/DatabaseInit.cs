using System;
using Portal.Domain.Entities;

namespace Portal.Infrastructure.Database
{
	internal class DatabaseInit
	{
		public IList<Product> GetProducts()
		{
			IList<Product> products = new List<Product>();

            products.Add(new Product
            {
                Id = 1,
                Name = "Rohlík",
                Description = "Jídlo",
                Price = 2,
                ImageSrc = "/img/product/produkty-01.jpg"
            });
            products.Add(new Product
            {
                Id = 2,
                Name = "Chleba",
                Description = "Nejlepší chleba",
                Price = 30,
                ImageSrc = "/img/product/produkty-02.jpg"
            });
            products.Add(new Product
            {
                Id = 3,
                Name = "Vánočka",
                Description = "Vánoce",
                Price = 60,
                ImageSrc = "/img/product/produkty-03.jpg"
            });

            return products;
		}

        public IList<Carousel> GetCarousels()
        {
            IList<Carousel> carousels = new List<Carousel>();

            carousels.Add(new Carousel
            {
                Id = 1,
                ImageSrc= "/img/carousel/how-to-become-an-information-technology-specialist160684886950141.jpg",
                ImageAlt = "First slide"
            });
            carousels.Add(new Carousel
            {
                Id = 2,
                ImageSrc = "/img/carousel/Information-Technology-1-1.jpg",
                ImageAlt = "Second slide"
            });
            carousels.Add(new Carousel
            {
                Id = 2,
                ImageSrc = "/img/carousel/itec-index-banner.jpg",
                ImageAlt = "Third slide"
            });

            return carousels;
        }
	}
}

