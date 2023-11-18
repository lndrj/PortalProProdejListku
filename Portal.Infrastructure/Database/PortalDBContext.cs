using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure.Database
{
    public class PortalDBContext : DbContext
    {
        public DbSet<Akce> Akces { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        
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
        }

    }
}
