using System;
namespace Portal.Domain.Entities
{
	public class Vstupenka : Entity<int>
	{
		public int AkceID { get; set; }
		public double Price { get; set; }
	}
}

