using System;
namespace Portal.Domain.Entities
{
	public class AdminRequest : Entity<int>
	{
		public string Request { get; set; }
		public bool Solved { get; set; }
	}
}

