using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;

namespace Portal.Application.Implementation
{
    public class AkceAdminDFService : IAkceAdminService
    {
        public IList<Akce> Select()
        {
            return DatabaseFake.Akces;
        }

        public void Create(Akce akce)
        {
            if (DatabaseFake.Akces != null && DatabaseFake.Akces.Count > 0)
            {
                akce.Id = DatabaseFake.Akces.Last().Id + 1;
            }
            else
                akce.Id = 1;

            DatabaseFake.Akces?.Add(akce);
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Akce? akce = DatabaseFake.Akces.FirstOrDefault(ak => ak.Id == id);

            if(akce != null)
            {
                deleted = DatabaseFake.Akces.Remove(akce);
            }

            return deleted;
        }

        public void Update(Akce akce)
        {
            Akce? aktualizovanaAkce = DatabaseFake.Akces.FirstOrDefault(ak => ak.Id == ak.Id);
            if (aktualizovanaAkce != null)
            {
            aktualizovanaAkce.Name = akce.Name;
            aktualizovanaAkce.Description = akce.Description;
            aktualizovanaAkce.Price = akce.Price;
            aktualizovanaAkce.ImageSrc = akce.ImageSrc;       
            }

        }
    }
}
