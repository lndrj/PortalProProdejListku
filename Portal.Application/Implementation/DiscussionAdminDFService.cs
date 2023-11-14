using System;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;

namespace Portal.Application.Implementation
{
        public class DiscussionAdminDFService : IDiscussionAdminService
        {
            public IList<Diskuze> Select()
            {
                return DatabaseFake.Discussions;
            }

            public bool Delete(int id)
            {
                bool deleted = false;

                Diskuze? diskuze = DatabaseFake.Discussions.FirstOrDefault(disc => disc.Id == id);

                if (diskuze != null)
                {
                    deleted = DatabaseFake.Discussions.Remove(diskuze);
                }

                return deleted;
            }
        }
}

