using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portal.Application.Abstraction;
using Portal.Domain.Entities;
using Portal.Infrastructure.Database;

namespace Portal.Application.Implementation
{
    public class AkceAdminService : IAkceAdminService
    {
        PortalDBContext _portalDbContext;
        public AkceAdminService(PortalDBContext portalDbContext)
        {
            _portalDbContext = portalDbContext;
        }
        public IList<Akce> Select()
        {
            return _portalDbContext.Akces.ToList();
        }

        public void Create(Akce akce)
        {

            _portalDbContext.Akces?.Add(akce);
            _portalDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Akce? akce = _portalDbContext.Akces.FirstOrDefault(ak => ak.Id == id);

            if (akce != null)
            {
                _portalDbContext.Akces.Remove(akce);
                _portalDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }

        public void Update(Akce akce)
        {
            Akce? aktualizovanaAkce = _portalDbContext.Akces.FirstOrDefault(a => a.Id == akce.Id);

            if (aktualizovanaAkce != null)
            {
                _portalDbContext.Entry(aktualizovanaAkce).State = EntityState.Detached;

                // Zde načtěte znovu aktuální entitu bez sledování
                aktualizovanaAkce = _portalDbContext.Akces.FirstOrDefault(a => a.Id == akce.Id);

                // Nastavte stav entity na Modified
                _portalDbContext.Entry(aktualizovanaAkce).State = EntityState.Modified;

                // Provádějte aktualizaci
                aktualizovanaAkce.Name = akce.Name;
                aktualizovanaAkce.Description = akce.Description;
                aktualizovanaAkce.Price = akce.Price;
                aktualizovanaAkce.ImageSrc = akce.ImageSrc;

                _portalDbContext.SaveChanges();
            }
        }
    }
}
