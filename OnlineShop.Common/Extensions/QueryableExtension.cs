using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using OnlineShop.Common.Abstractions;
using OnlineShop.Common.Enums;

namespace OnlineShop.Common.Extensions
{
    public static class QueryableExtension
    {
        public static IQueryable<T> OrderByDynamic<T, TOrderBy>(this IQueryable<T> query, TOrderBy orderBy, IDictionary<string, string> alias = null, char nestedSeparator = '.')
            where T : class
            where TOrderBy : IOrderBy
        {
            // if there are no such order by, skip the order
            if (string.IsNullOrEmpty(orderBy.OrderBy))
                return query;
            
            // if any alias, find order by using alias
            if (alias != null && alias.TryGetValue(orderBy.OrderBy, out var by))
                orderBy.OrderBy = by;
            
            // dynamically creates a call like this: query.OrderBy(p =&gt; p.SortColumn)
            var parameter = Expression.Parameter(typeof(T), "p");
            
            // set order wether Ascending or Descending
            var command = orderBy.OrderType == OrderType.Asc ? "OrderBy" : "OrderByDescending";

            // recursively find properties
            var nestedProperty = orderBy.OrderBy.Split(nestedSeparator);
            var property = GetPropertyFrom<T>(nestedProperty, nestedProperty.Last())
                ?? throw new ArgumentException($"Field {orderBy.OrderBy} or {orderBy.OrderBy.ToUpperFirst()} is not found", nameof(orderBy));

            // this is the part p.SortColumn
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);

            // this is the part p =&gt; p.SortColumn
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);

            // finally, call the "OrderBy" / "OrderByDescending" method with the order by lamba expression
            var resultExpression = Expression.Call(
                typeof(Queryable), command, new Type[] { typeof(T), property.PropertyType }, 
                query.Expression, Expression.Quote(orderByExpression));

            return query.Provider.CreateQuery<T>(resultExpression);
        }

        public static IQueryable<T> SetPagination<T, TGetAll>(this IQueryable<T> query, TGetAll pagination)
            where T : class
            where TGetAll : IGetAll
        {
            return pagination.GetAll.HasValue && pagination.GetAll.Value
                ? query
                : query.Skip(pagination.CalculateOffset()).Take(pagination.Size);
        }

        private static PropertyInfo GetPropertyFrom<T>(ReadOnlySpan<string> fullPropName, string propName)
        {
            return fullPropName.Length switch
            {
                0 => null,
                1 => typeof(T).GetProperty(propName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance),
                _ => GetPropertyFrom<T>(fullPropName.Slice(1), propName)
            };
        }
    }
}