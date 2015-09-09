using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnockoutPager.Models;

namespace KnockoutPager.Searcher
{
    public interface IPaginationSearcher
    {
        PaginationResultModel Search<T>(PaginationSearchModel model);
        IEnumerable<T> GetBaseSet<T>(PaginationSearchModel model);
        IEnumerable<T> ApplyFilters<T>(PaginationSearchModel model, IEnumerable<T> results);
        IEnumerable<T> ApplyOffset<T>(PaginationSearchModel model, IEnumerable<T> results);
        IEnumerable<T> ApplySorting<T>(PaginationSearchModel model, IEnumerable<T> results);
        IEnumerable<T> ApplyResultSize<T>(PaginationSearchModel model, IEnumerable<T> results);
    }
}
