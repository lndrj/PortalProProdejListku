using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure.Database
{
    public class PortalDBContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Akce> Akces { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Diskuze> Discussions { get; set; }
        public DbSet<AdminRequest> Requests { get; set; }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public PortalDBContext(DbContextOptions options) : base(options) 
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DatabaseInit dbInit = new DatabaseInit();

            modelBuilder.Entity<Akce>().HasData(dbInit.GetAkces());
            modelBuilder.Entity<Carousel>().HasData(dbInit.GetCarousels());


            //Identity - Role a User inicializace
            modelBuilder.Entity<Role>().HasData(dbInit.CreateRoles());

            (User admin, List<IdentityUserRole<int>> adminUserRoles) = dbInit.CreateAdminWithRoles();
            (User manager, List<IdentityUserRole<int>> managerUserRoles) = dbInit.CreateManagerWithRoles();

            modelBuilder.Entity<User>().HasData(admin, manager);

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(managerUserRoles);
        }

    }
}
