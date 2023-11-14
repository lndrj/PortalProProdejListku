using System;
using Portal.Domain.Entities;

namespace Portal.Application.Abstraction
{
	public interface IDiscussionAdminService
	{
        IList<Diskuze> Select();
        bool Delete(int id);
    }
}

