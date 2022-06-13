namespace SqlQueryCreator.Services;

using SqlQueryCreator.Models;
using SqlQueryCreator.QueryBuilders;

public class SqlQueryService : IQueryService
{
    public string BuildSqlQuery(Data data)
    {
        var query = String.Empty;
        if (data.Joins is null)
        {
            query = BuildSingleTableSqlQuery(data.QueryData[0]);
        }
        else
        {
            query = BuildMultipleTableSqlQuery(data);
        }
        return query;

    }

    private static string BuildSingleTableSqlQuery(QueryData queryData)
    {
        var sqlqueryBuilder = new SqlQueryBuilder();
        var sqlQueryGenerator = new SqlQueryGenerator(sqlqueryBuilder);

        sqlQueryGenerator.CreateSqlQuery(queryData);
        var query = sqlQueryGenerator.GetSqlQuery();
        return query;
    }
    private static string BuildMultipleTableSqlQuery(Data data)
    {
        var sqlMultipleQueryBuilder = new SqlMultipleQueryBuilder();
        var sqlMultipleQueryGenerator = new SqlMultipleQueryGenerator(sqlMultipleQueryBuilder);

        sqlMultipleQueryGenerator.CreateSqlQuery(data);
        var query = sqlMultipleQueryGenerator.GetSqlQuery();
        return query;
    }
}