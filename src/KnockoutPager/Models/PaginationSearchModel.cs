using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockoutPager.Models
{
    public class PaginationSearchModel
    {
        public IDictionary<string, string> Filters { get; set; }
        public string OrderBy { get; set; }
        public bool ReverseSort { get; set; }
        public int? ResultSize { get; set; }
        public int Offset { get; set; }

        public PaginationSearchModel()
        {
            Filters = new Dictionary<string, string>();
        }
    }
}
