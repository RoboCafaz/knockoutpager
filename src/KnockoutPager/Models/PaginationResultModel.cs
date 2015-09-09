using System.Collections;
using System.Linq;

namespace KnockoutPager.Models
{
    public class PaginationResultModel
    {
        public int Count { get; set; }
        public IEnumerable Results { get; set; }

        public PaginationResultModel()
        {
            Results = Enumerable.Empty<object>();
        }
    }
}
