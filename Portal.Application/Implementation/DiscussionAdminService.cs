using System;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;

namespace Portal.Application.Implementation
{
    public class DiscussionAdminService : IDiscussionAdminService
    {
        PortalDBContext _portalDbContext;
        public DiscussionAdminService(PortalDBContext portalDbContext)
        {
            _portalDbContext = portalDbContext;
        }
        public IList<Diskuze> Select()
        {
            return _portalDbContext.Discussions.ToList();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Diskuze? diskuze = _portalDbContext.Discussions.FirstOrDefault(disc => disc.Id == id);

            if (diskuze != null)
            {
                _portalDbContext.Discussions.Remove(diskuze);
                _portalDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }
    }
}

