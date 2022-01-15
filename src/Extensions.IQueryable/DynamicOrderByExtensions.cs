using System;

namespace Tolitech.CodeGenerator.Extensions.IQueryable
{
    public static class DynamicOrderByExtensions
    {
        public static IQueryable<TEntity> DynamicOrderBy<TEntity>(this IQueryable<TEntity> query, string orderByColumns) // where TEntity : Entity
        {
            if (!string.IsNullOrEmpty(orderByColumns))
            {
                string[] columns = orderByColumns.Split(',');
                bool firstColumn = true;

                foreach (string column in columns)
                {
                    string[] columnWithOrder = column.Trim().Split(':');
                    bool ascending = true;
                    string columnName = columnWithOrder[0];

                    if (columnWithOrder.Length > 1 && columnWithOrder[1].ToLower().Contains("desc"))
                    {
                        ascending = false;
                    }

                    query = query.OrderByField(columnName, ascending, firstColumn);
                    firstColumn = false;
                }
            }

            return query;
        }
    }
}
