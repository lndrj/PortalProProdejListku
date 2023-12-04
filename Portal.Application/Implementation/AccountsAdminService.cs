using System;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;

namespace Portal.Application.Implementation
{
    public class AccountsAdminService : IAccountsAdminService
    {
        PortalDBContext _portalDbContext;
        public AccountsAdminService(PortalDBContext portalDbContext)
        {
            _portalDbContext = portalDbContext;
        }
        public IList<Account> Select()
        {
            return _portalDbContext.Accounts.ToList();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Account? account = _portalDbContext.Accounts.FirstOrDefault(acc => acc.Id == id);

            if (account != null)
            {
                _portalDbContext.Accounts.Remove(account);
                _portalDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }

        public void Update(Account account)
        {
            Account? aktualizovanyUcet = _portalDbContext.Accounts.FirstOrDefault(acc => acc.Id == account.Id);

            if (aktualizovanyUcet != null)
            {
                aktualizovanyUcet.IsAdmin = !aktualizovanyUcet.IsAdmin;
                _portalDbContext.Update(aktualizovanyUcet);
                _portalDbContext.SaveChanges();
            }
        }
    }
}

