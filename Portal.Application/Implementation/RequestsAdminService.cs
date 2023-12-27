using System;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;

namespace Portal.Application.Implementation
{
    public class RequestsAdminService : IRequestsAdminService
    {
        PortalDBContext _portalDbContext;
        public RequestsAdminService(PortalDBContext portalDbContext)
        {
            _portalDbContext = portalDbContext;
        }
        public IList<AdminRequest> Select()
        {
            return _portalDbContext.Requests.ToList();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            AdminRequest? adminRequest = _portalDbContext.Requests.FirstOrDefault(req => req.Id == id);

            if (adminRequest != null)
            {
                _portalDbContext.Requests.Remove(adminRequest);
                _portalDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }

        public void Update(int id)
        {
            AdminRequest? aktualizovanyRequest = _portalDbContext.Requests.FirstOrDefault(req => req.Id == id);
            if (aktualizovanyRequest != null)
            {
                aktualizovanyRequest.Solved = !aktualizovanyRequest.Solved;
                _portalDbContext.Update(aktualizovanyRequest);
                _portalDbContext.SaveChanges();
            }
        }

		public void Create(AdminRequest adminRequest)
		{
			_portalDbContext.Requests.Add(adminRequest);
			_portalDbContext.SaveChanges();
		}
	}
}

