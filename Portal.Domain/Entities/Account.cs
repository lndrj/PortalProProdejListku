using System;
namespace Portal.Domain.Entities
{
	public class Account : Entity<int>
	{
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
		public string Password { get; set; }
		public string PhoneNumber { get; set; }
		public bool IsAdmin { get; set; }
		public DateTime DateCreated { get; set; }
	}
}

