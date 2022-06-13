namespace SqlQueryCreator.QueryBuilders;

using System.Text;
using SqlQueryCreator.Enums;
using SqlQueryCreator.Models;

public class SqlMultipleQueryBuilder : IMultipleQueryBuilder
{
    public StringBuilder sqlQuery = new StringBuilder();
    public void HandleSelect()
    {
        sqlQuery.Append("SELECT ");
    }

    public void HandleMultipleTableSelectedColumns(List<QueryData> queriesData)
    {
        foreach (var query in queriesData)
        {
            HandleSelectedColumns(query.SelectedColumns, query.TableName);
        }
        sqlQuery.Remove(sqlQuery.Length - 2, 1);
    }

    public void HandleSelectedColumns(string[] selectedColumns, string tableName)
    {
        if (selectedColumns is null)
        {
            sqlQuery.Append($"{tableName}.* ");
        }
        else
        {
            foreach (var column in selectedColumns)
                sqlQuery.Append($"{tableName}.{column}, ");

        }
    }

    public void HandleJoins(List<Join> joins)
    {
        sqlQuery.Append($"FROM {joins[0].FromTable} ");
        foreach (var join in joins)
        {
            AddJoinType(join.JoinType);
            sqlQuery.Append($"{join.ToTable} ON {join.FromTable}.{join.FromColumn}");
            AddComparisonOperator(join.ComparisonOperator);
            sqlQuery.Append($"{join.ToTable}.{join.ToColumn}");
        }
    }

    public void EndQuery()
    {
        sqlQuery.Append(";");
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

    public void AddJoinType(JoinType joinType)
    {
        switch (joinType)
        {
            case JoinType.InnerJoin:
                sqlQuery.Append(" INNER JOIN "); break;
            case JoinType.RightJoin:
                sqlQuery.Append(" RIGHT JOIN "); break;
            case JoinType.LeftJoin:
                sqlQuery.Append(" LEFT JOIN "); break;
            case JoinType.OuterJoin:
                sqlQuery.Append(" OUTER JOIN "); break;
        }
    }

    public string GetQuery() => sqlQuery.ToString();
    public void ClearQuery() => sqlQuery.Clear();
}