using System;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;

namespace Portal.Application.Implementation
{
	public class RequestsAdminDFService : IRequestsAdminService
	{
        public IList<AdminRequest> Select()
        {
            return DatabaseFake.Requests;
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            AdminRequest? adminRequest = DatabaseFake.Requests.FirstOrDefault(req => req.Id == id);

            if (adminRequest != null)
            {
                deleted = DatabaseFake.Requests.Remove(adminRequest);
            }

            return deleted;
        }

        public void Update(AdminRequest adminRequest)
        {
            AdminRequest? aktualizovanyRequest = DatabaseFake.Requests.FirstOrDefault(req => req.Id == req.Id);
            if (aktualizovanyRequest != null)
            {
                aktualizovanyRequest.Solved = !aktualizovanyRequest.Solved;
            }
        }
    }
}

