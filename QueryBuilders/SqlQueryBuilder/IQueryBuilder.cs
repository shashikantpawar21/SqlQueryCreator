namespace SqlQueryCreator.QueryBuilders;

using SqlQueryCreator.Models;

public interface IQueryBuilder
{
    void HandleSelect();
    void HandleSelectedColumns(string[] selectedColumns);
    void HandleTableName(string tableName);
    void HandleWhereClause(WhereClause whereClause);
    string GetQuery();
    void ClearQuery();
    void EndQuery();
}