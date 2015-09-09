using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KnockoutPager.Models;

namespace KnockoutPager.Searcher
{
    public abstract class DefaultPaginationSearcher : IPaginationSearcher
    {
        public PaginationResultModel Search<T>(PaginationSearchModel model)
        {
            var results = GetBaseSet<T>(model);
            results = ApplyFilters(model, results);
            results = ApplySorting(model, results);
            var count = results.Count();
            results = ApplyOffset(model, results);
            results = ApplyResultSize(model, results);
            return new PaginationResultModel { Count = count, Results = results };
        }

        public abstract IEnumerable<T> GetBaseSet<T>(PaginationSearchModel model);

        public abstract IEnumerable<T> ApplyFilters<T>(PaginationSearchModel model, IEnumerable<T> results);

        public IEnumerable<T> ApplySorting<T>(PaginationSearchModel model, IEnumerable<T> results)
        {
            var sort = model.OrderBy;
            if (!String.IsNullOrWhiteSpace(sort))
            {
                if (model.ReverseSort)
                {
                    sort += "DESC";
                }
                //results = results.OrderBy(sort);
            }
            return results;
        }

        public IEnumerable<T> ApplyOffset<T>(PaginationSearchModel model, IEnumerable<T> results)
        {
            var offset = model.Offset;
            if (offset > 0)
            {
                results = results.Skip(offset);
            }
            else if (offset < 0)
            {
                throw new ArgumentException("Must not be negative.", "model.Offset");
            }
            return results;
        }

        public IEnumerable<T> ApplyResultSize<T>(PaginationSearchModel model, IEnumerable<T> results)
        {
            var resultSize = model.ResultSize;
            if (resultSize.HasValue)
            {
                if (resultSize > 0)
                {
                    results = results.Take(resultSize.Value);
                }
                else if (resultSize <= 0)
                {
                    throw new ArgumentException("Must be greater-than zero.", "model.ResultSize");
                }
            }
            return results;
        }
    }
}
