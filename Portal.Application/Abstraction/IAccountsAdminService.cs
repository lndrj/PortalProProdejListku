using System;
using Portal.Domain.Entities;

namespace Portal.Application.Abstraction
{
	public interface IAccountsAdminService
	{
		IList<Account> Select();
        bool Delete(int id);
        public void Update(Account account);
    }
}

