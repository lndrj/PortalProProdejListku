using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    public class AkceDetailViewModel
    {
        public Akce Akce { get; set; }
        public IList<Diskuze> Diskuze { get; set; }
        public string NewComment { get; set; }

    }
}
