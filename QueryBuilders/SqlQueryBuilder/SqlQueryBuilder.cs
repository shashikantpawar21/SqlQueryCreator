namespace SqlQueryCreator.QueryBuilders;

using System.Text;
using SqlQueryCreator.Enums;
using SqlQueryCreator.Models;

public class SqlQueryBuilder : IQueryBuilder
{
    public StringBuilder sqlQuery = new StringBuilder();
    public void HandleSelect()
    {
        sqlQuery.Append("SELECT ");
    }

    public void HandleSelectedColumns(string[] selectedColumns)
    {
        if (selectedColumns is null)
        {
            sqlQuery.Append("* ");
        }
        else
        {
            foreach (var column in selectedColumns)
                sqlQuery.Append(column + ", ");
            sqlQuery.Remove(sqlQuery.Length - 2, 1);
        }
    }

    public void HandleTableName(string tableName)
    {
        sqlQuery.Append($"FROM {tableName} ");
    }

    public void HandleWhereClause(WhereClause whereClause)
    {
        if (whereClause is null)
        {
            return;
        }
        if (whereClause.RangeFilters is null && whereClause.RangeFilters is null)
        {
            return;
        }

        sqlQuery.Append("WHERE ");

        if (whereClause.ComparisonFilters is not null)
        {
            HandleComparisonFilters(whereClause.ComparisonFilters);
        }

        if (whereClause.RangeFilters is not null)
        {
            HandleRangeFilters(whereClause.RangeFilters);
        }

        sqlQuery.Replace(" ", "", sqlQuery.Length - 2, 2);
    }


    public void HandleComparisonFilters(List<ComparisonFilter> comparisonFilters)
    {
        foreach (var filter in comparisonFilters)
        {
            sqlQuery.Append($"({filter.ColumnName} ");
            AddComparisonOperator(filter.Operator);
            sqlQuery.Append($"{filter.FilterValue}) {filter.NextConditionLinkOperator} ");
        }


    }
    public void HandleRangeFilters(List<RangeFilter> rangeFilters)
    {

        foreach (var filter in rangeFilters)
        {
            sqlQuery.Append($"({filter.ColumnName} ");
            AddRangeQuery(filter.Operator, filter.FilterValues);
            sqlQuery.Append($" {filter.NextConditionLinkOperator} ");
        }


    }

    public void AddComparisonOperator(ComparisonOperator comparisonOperator)
    {
        switch (comparisonOperator)
        {
            case ComparisonOperator.Equals:
                sqlQuery.Append(" == "); break;
            case ComparisonOperator.NotEquals:
                sqlQuery.Append(" <> "); break;
            case ComparisonOperator.GreaterThan:
                sqlQuery.Append(" > "); break;
            case ComparisonOperator.GreaterOrEquals:
                sqlQuery.Append(" >= "); break;
            case ComparisonOperator.LessThan:
                sqlQuery.Append(" < "); break;
            case ComparisonOperator.LessOrEquals:
                sqlQuery.Append(" <= "); break;
            case ComparisonOperator.Like:
                sqlQuery.Append(" LIKE "); break;
        }
    }
    public void AddRangeQuery(RangeOperator rangeOperator, List<string> values)
    {
        switch (rangeOperator)
        {
            case RangeOperator.In:
                {
                    sqlQuery.Append(" in (");
                    foreach (var value in values)
                    {
                        sqlQuery.Append($"{value}, ");
                    }
                    sqlQuery.Replace(",", "))", sqlQuery.Length - 2, 1);
                }
                break;

            case RangeOperator.Between:
                sqlQuery.Append($" BETWEEN {values[0]} AND {values[1]})"); break;
        }
    }

    public void EndQuery()
    {
        sqlQuery.Append(";");
    }

    public string GetQuery() => sqlQuery.ToString();
    public void ClearQuery() => sqlQuery.Clear();
}