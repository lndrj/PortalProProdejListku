using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Domain.Entities;

namespace Portal.Infrastructure.Database
{
    public class DatabaseFake
    {
        public static List<Akce> Akces { get; set; }
        public static List<Account> Accounts { get; set; }
        public static List<Diskuze> Discussions { get; set; }
        public static List<AdminRequest> Requests { get; set; }
        public static List<Carousel> Carousels { get; set; }


        static DatabaseFake()
        {
            DatabaseInit databaseInit = new DatabaseInit();
            Akces = databaseInit.GetAkces().ToList();
            Accounts = databaseInit.GetAccounts().ToList();
            Discussions = databaseInit.GetDiscussions().ToList();
            Requests = databaseInit.GetRequests().ToList();
            Carousels = databaseInit.GetCarousels().ToList();
            
        }
    }
}
