using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.DAL.Helpers
{
    public static class OrderByExtension
    {
        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, string orderByProperty, bool ascending = true)
        {
            if (string.IsNullOrWhiteSpace(orderByProperty))
                return query;

            var entityType = typeof(T);
            var property = entityType.GetProperty(orderByProperty, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null)
                return query; 

            var parameter = Expression.Parameter(entityType, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            var methodName = ascending ? "OrderBy" : "OrderByDescending";

            var resultExp = Expression.Call(typeof(Queryable), methodName, new Type[] { entityType, property.PropertyType },
                                            query.Expression, Expression.Quote(orderByExp));

            return query.Provider.CreateQuery<T>(resultExp);
        }
    }
}
