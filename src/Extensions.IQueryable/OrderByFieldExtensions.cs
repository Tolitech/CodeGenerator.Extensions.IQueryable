using System;
using System.Linq.Expressions;

namespace Tolitech.CodeGenerator.Extensions.IQueryable
{
    internal static class OrderByFieldExtensions
    {
        internal static IQueryable<TEntity> OrderByField<TEntity>(this IQueryable<TEntity> q, string sortField, bool ascending, bool firstColumn = true) // where TEntity : Entity
        {
            var param = Expression.Parameter(typeof(TEntity), "p");

            string[] propertiesName = sortField.Split('.');
            MemberExpression prop = Expression.Property(param, propertiesName[0]);

            for (int index = 1; index < propertiesName.Length; index++)
            {
                prop = Expression.Property(prop, propertiesName[index]);
            }

            var exp = Expression.Lambda(prop, param);
            string method = ascending ? "OrderBy" : "OrderByDescending";

            if (!firstColumn)
                method = ascending ? "ThenBy" : "ThenByDescending";

            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<TEntity>(mce);
        }
    }
}