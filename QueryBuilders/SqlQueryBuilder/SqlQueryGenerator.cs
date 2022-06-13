namespace SqlQueryCreator.QueryBuilders;

using SqlQueryCreator.Models;

public class SqlQueryGenerator
{
    private IQueryBuilder _sqlQueryBuilder;
    public SqlQueryGenerator(IQueryBuilder sqlQueryBuilder)
    {
        _sqlQueryBuilder = sqlQueryBuilder;
    }
    public void CreateSqlQuery(QueryData queryData)
    {
        _sqlQueryBuilder.ClearQuery();
        _sqlQueryBuilder.HandleSelect();
        _sqlQueryBuilder.HandleSelectedColumns(queryData.SelectedColumns);
        _sqlQueryBuilder.HandleTableName(queryData.TableName);
        _sqlQueryBuilder.HandleWhereClause(queryData.WhereClause);
        _sqlQueryBuilder.EndQuery();
    }

    public string GetSqlQuery()
    {
        return _sqlQueryBuilder.GetQuery();
    }
}