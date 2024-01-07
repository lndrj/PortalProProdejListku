using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    public class AkceListViewModel
    {
        public IList<Akce> AkceList { get; set; }
        public string Search { get; set; }
        public DateTime? DateFilter {  get; set; }
		public double? MinPriceFilter { get; set; }
		public double? MaxPriceFilter { get; set; }

		//Stránkování
		public int Page { get; set; }
		public int PageSize { get; set; }
		public int TotalItems { get; set; }
		public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);

	}
}
