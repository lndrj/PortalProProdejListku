using System;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;

namespace Portal.Application.Implementation
{
    public class AccountsAdminDFService : IAccountsAdminService
    {
        public IList<Account> Select()
        {
            return DatabaseFake.Accounts;
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Account? account = DatabaseFake.Accounts.FirstOrDefault(acc => acc.Id == id);

            if (account != null)
            {
                deleted = DatabaseFake.Accounts.Remove(account);
            }

            return deleted;
        }

       public void Update(Account account)
        {
            Account? aktualizovanyUcet = DatabaseFake.Accounts.FirstOrDefault(acc => acc.Id == acc.Id);
            if(aktualizovanyUcet != null)
            {
                aktualizovanyUcet.IsAdmin = !aktualizovanyUcet.IsAdmin;
            }
        }
    }
}

