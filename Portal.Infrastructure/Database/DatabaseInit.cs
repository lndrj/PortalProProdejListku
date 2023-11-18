using System;
using Portal.Domain.Entities;

namespace Portal.Infrastructure.Database
{
	internal class DatabaseInit
	{
		public IList<Akce> GetAkces()
		{
			IList<Akce> akces = new List<Akce>();

            akces.Add(new Akce
            {
                Id = 1,
                Name = "Rohlík",
                Description = "Jídlo",
                Price = 2,
                ImageSrc = "/img/product/produkty-01.jpg"
            });
            akces.Add(new Akce
            {
                Id = 2,
                Name = "Chleba",
                Description = "Nejlepší chleba",
                Price = 30,
                ImageSrc = "/img/product/produkty-02.jpg"
            });
            akces.Add(new Akce
            {
                Id = 3,
                Name = "Vánočka",
                Description = "Vánoce",
                Price = 60,
                ImageSrc = "/img/product/produkty-03.jpg"
            });

            return akces;
		}

        public IList<Account> GetAccounts()
        {
            IList<Account> accounts = new List<Account>();

            accounts.Add(new Account
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "password123",
                PhoneNumber = "123456789",
                IsAdmin = true, 
                DateCreated = DateTime.Now
            });

            accounts.Add(new Account
            {
                Id = 2,
                FirstName = "Alice",
                LastName = "Smith",
                Email = "alice.smith@example.com",
                Password = "securepassword",
                PhoneNumber = "987654321",
                IsAdmin = false, 
                DateCreated = DateTime.Now
            });

            accounts.Add(new Account
            {
                Id = 3,
                FirstName = "Bob",
                LastName = "Johnson",
                Email = "bob.johnson@example.com",
                Password = "bobpassword",
                PhoneNumber = "555555555",
                IsAdmin = true, 
                DateCreated = DateTime.Now
            });

            return accounts;
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
<<<<<<< Updated upstream
                Id = 2,
=======
                Id = 3,
>>>>>>> Stashed changes
                ImageSrc = "/img/carousel/itec-index-banner.jpg",
                ImageAlt = "Third slide"
            });

            return carousels;
        }

        public IList<Diskuze> GetDiscussions()
        {
            IList<Diskuze> discussions = new List<Diskuze>();

            discussions.Add(new Diskuze
            {
                Id = 1,
                UserID = 1,
                AkceID = 1,
                Komentar = "První komentář k akci 1."
            });

            discussions.Add(new Diskuze
            {
                Id = 2,
                UserID = 2,
                AkceID = 1,
                Komentar = "Druhý komentář k akci 1."
            });

            discussions.Add(new Diskuze
            {
                Id = 3,
                UserID = 3,
                AkceID = 2,
                Komentar = "Komentář k akci 2."
            });

            return discussions;
        }

        public IList<AdminRequest> GetRequests()
        {
            IList<AdminRequest> requests = new List<AdminRequest>();

            requests.Add(new AdminRequest
            {
                Id = 1,
                Request = "První žádost na admina.",
                Solved = false
            });

            requests.Add(new AdminRequest
            {
                Id = 2,
                Request = "Druhá žádost na admina.",
                Solved = true
            });

            requests.Add(new AdminRequest
            {
                Id = 3,
                Request = "Třetí žádost na admina.",
                Solved = false
            });


            return requests;
        }
    }
}

