using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Api.Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderByAsc { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderByAsc(Expression<Func<T, object>> expression)
        {
            OrderByAsc = expression;
        }
        protected void AddOrderByDesc(Expression<Func<T, object>> expression)
        {
            OrderByDesc = expression;
        }
    }
}