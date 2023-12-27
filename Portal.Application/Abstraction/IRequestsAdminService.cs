using System;
using Portal.Domain.Entities;

namespace Portal.Application.Abstraction
{
	public interface IRequestsAdminService
	{
		IList<AdminRequest> Select();
        bool Delete(int id);
        public void Update(int id);
		void Create(AdminRequest adminRequest);
	}
}

