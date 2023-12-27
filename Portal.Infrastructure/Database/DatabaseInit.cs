using System;
using Microsoft.AspNetCore.Identity;
using Portal.Domain.Entities;
using Portal.Infrastructure.Identity;

namespace Portal.Infrastructure.Database
{
    internal class DatabaseInit
    {
        public IList<Akce> GetAkces()
        {
            IList<Akce> akces = new List<Akce>();

            // Taylor Swift - Eras Tour
            akces.Add(new Akce
            {
                Id = 1,
                Name = "Taylor Swift - Eras Tour",
                Description = "Taylor Swift's Eras Tour",
                Price = 100.00,
                Date = DateTime.Now.AddMonths(1), // Datum za 1 měsíc od dnešního data
                Time = DateTime.Now.AddMonths(1).AddHours(19), // Čas za 1 měsíc od dnešního data, 19:00
                ImageSrc = "/img/product/taylor-swift.jpg",
                ImageSrcDetail = "/img/product/taylor-swift-detail.jpg",
                PocetVstupenek = 1000
            });

            // Ed Sheeran - World Tour
            akces.Add(new Akce
            {
                Id = 2,
                Name = "Ed Sheeran - World Tour",
                Description = "Ed Sheeran's World Tour",
                Price = 80.00,
                Date = DateTime.Now.AddMonths(2), // Datum za 2 měsíce od dnešního data
                Time = DateTime.Now.AddMonths(2).AddHours(20), // Čas za 2 měsíce od dnešního data, 20:00
                ImageSrc = "/img/product/ed-sheeran.jpg",
                ImageSrcDetail = "/img/product/ed-sheeran-detail.jpg",
                PocetVstupenek = 1500
            });

            // John Mayer - Summer Tour
            akces.Add(new Akce
            {
                Id = 3,
                Name = "John Mayer - Solo Tour",
                Description = "John Mayer's Solo Tour",
                Price = 75.00,
                Date = DateTime.Now.AddMonths(3), // Datum za 3 měsíce od dnešního data
                Time = DateTime.Now.AddMonths(3).AddHours(18), // Čas za 3 měsíce od dnešního data, 18:00
                ImageSrc = "/img/product/john-mayer.jpg",
                ImageSrcDetail = "/img/product/john-mayer-detail.jpg",
                PocetVstupenek = 1200
            });

            // Olivia Rodrigo - Sour Tour
            akces.Add(new Akce
            {
                Id = 4,
                Name = "Olivia Rodrigo - Guts Tour",
                Description = "Olivia Rodrigo's Guts Tour",
                Price = 90.00,
                Date = DateTime.Now.AddMonths(4), // Datum za 4 měsíce od dnešního data
                Time = DateTime.Now.AddMonths(4).AddHours(21), // Čas za 4 měsíce od dnešního data, 21:00
                ImageSrc = "/img/product/olivia-rodrigo.jpg",
                ImageSrcDetail = "/img/product/olivia-rodrigo-detail.jpg",
                PocetVstupenek = 800
            });

            // Gracie Abrams - Acoustic Showcase
            akces.Add(new Akce
            {
                Id = 5,
                Name = "Gracie Abrams - Acoustic Showcase",
                Description = "Gracie Abrams' Acoustic Showcase",
                Price = 60.00,
                Date = DateTime.Now.AddMonths(5), // Datum za 5 měsíců od dnešního data
                Time = DateTime.Now.AddMonths(5).AddHours(17), // Čas za 5 měsíců od dnešního data, 17:00
                ImageSrc = "/img/product/gracie-abrams.jpg",
                ImageSrcDetail = "/img/product/gracie-abrams-detail.jpg",
                PocetVstupenek = 900
            });

            return akces;
        }
        /*
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
        */
        public IList<Carousel> GetCarousels()
        {
            IList<Carousel> carousels = new List<Carousel>();

            carousels.Add(new Carousel
            {
                Id = 1,
                ImageSrc = "/img/carousel/how-to-become-an-information-technology-specialist160684886950141.jpg",
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
                Id = 3,
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

        public List<Role> CreateRoles()
        {
            List<Role> roles = new List<Role>();

            Role roleAdmin = new Role()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
            };

            Role roleManager = new Role()
            {
                Id = 2,
                Name = "Manager",
                NormalizedName = "MANAGER",
                ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660"
            };

            Role roleCustomer = new Role()
            {
                Id = 3,
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee"
            };


            roles.Add(roleAdmin);
            roles.Add(roleManager);
            roles.Add(roleCustomer);

            return roles;
        }


        public (User, List<IdentityUserRole<int>>) CreateAdminWithRoles()
        {
            User admin = new User()
            {
                Id = 1,
                FirstName = "Adminek",
                LastName = "Adminovy",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.cz",
                NormalizedEmail = "ADMIN@ADMIN.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==",
                SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            List<IdentityUserRole<int>> adminUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 1
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 3
                }
            };

            return (admin, adminUserRoles);
        }


        public (User, List<IdentityUserRole<int>>) CreateManagerWithRoles()
        {
            User manager = new User()
            {
                Id = 2,
                FirstName = "Managerek",
                LastName = "Managerovy",
                UserName = "manager",
                NormalizedUserName = "MANAGER",
                Email = "manager@manager.cz",
                NormalizedEmail = "MANAGER@MANAGER.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==",
                SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            List<IdentityUserRole<int>> managerUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 3
                }
            };

            return (manager, managerUserRoles);
        }
    }
}