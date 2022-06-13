namespace SqlQueryCreator.QueryBuilders;

using SqlQueryCreator.Models;

public class SqlMultipleQueryGenerator
{
    private IMultipleQueryBuilder _sqlMultipleQueryBuilder;
    public SqlMultipleQueryGenerator(IMultipleQueryBuilder sqlQueryBuilder)
    {
        _sqlMultipleQueryBuilder = sqlQueryBuilder;
    }
    public void CreateSqlQuery(Data data)
    {
        _sqlMultipleQueryBuilder.ClearQuery();
        _sqlMultipleQueryBuilder.HandleSelect();
        _sqlMultipleQueryBuilder.HandleMultipleTableSelectedColumns(data.QueryData);
        _sqlMultipleQueryBuilder.HandleJoins(data.Joins);
        _sqlMultipleQueryBuilder.EndQuery();
    }

    public string GetSqlQuery()
    {
        return _sqlMultipleQueryBuilder.GetQuery();
    }
}