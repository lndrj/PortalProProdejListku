using System;
namespace Portal.Domain.Entities
{
	public class BuyHistory : Entity<int>
	{
		public int OrderID { get; set; }
		public int UserID { get; set; }
		public int AkceId { get; set; }
	}
}

