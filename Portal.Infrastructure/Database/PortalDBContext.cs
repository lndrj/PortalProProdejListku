using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Infrastructure.Identity;
using Portal.Web.Models.Database.Configuration;
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
            modelBuilder.Entity<AdminRequest>().HasData(dbInit.GetRequests());
            modelBuilder.Entity<Diskuze>().HasData(dbInit.GetDiscussions());
            
            
            //Staré
            //modelBuilder.Entity<Account>().HasData(dbInit.GetAccounts());
            


            //Identity - User and Role initialization
            //roles must be added first
            modelBuilder.Entity<Role>().HasData(dbInit.CreateRoles());

            //then, create users ..
            (User admin, List<IdentityUserRole<int>> adminUserRoles) = dbInit.CreateAdminWithRoles();
            (User manager, List<IdentityUserRole<int>> managerUserRoles) = dbInit.CreateManagerWithRoles();

            //.. and add them to the table
            modelBuilder.Entity<User>().HasData(admin, manager);

            //and finally, connect the users with the roles
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(managerUserRoles);

            //Přidané
            //configuration of User entity using IUser interface property inside Order entity
            modelBuilder.Entity<Order>().HasOne<User>(e => e.User as User);


            //configure DateTimeCreated for Order entity from configuration class
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration_MySQL());
        }
    }
}
