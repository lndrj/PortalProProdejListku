using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Domain.Entities;

namespace Portal.Application.Abstraction
{
    public interface IAkceAdminService
    {
        IList<Akce> Select();
        void Create(Akce akce);
        bool Delete(int id);
        public void Update(Akce akce);
    }
}
