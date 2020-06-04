using System.Linq;
using Api.Core.Entities;
using Api.Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Data.EntityFrameworkCore
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderByAsc != null)
            {
                query = query.OrderBy(spec.OrderByAsc);
            }

            if (spec.OrderByDesc != null)
            {
                query = query.OrderByDescending(spec.OrderByDesc);
            }

            if (spec.IsPagingEnabled)
            {
                query = query.Take(spec.Take).Skip(spec.Skip);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}