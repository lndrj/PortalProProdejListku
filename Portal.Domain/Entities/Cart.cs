using System;
namespace Portal.Domain.Entities
{
	public class Cart :	Entity<int>
	{
        public int CartID { get; set; }
        public int AkceID { get; set; }

        public int PocetListku { get; set; }
        public double Price { get; set; }

        public Akce Akce { get; set; }
    }
}

