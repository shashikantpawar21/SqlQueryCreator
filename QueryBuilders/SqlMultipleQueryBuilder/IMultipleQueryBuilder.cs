namespace SqlQueryCreator.QueryBuilders;

using SqlQueryCreator.Models;

public interface IMultipleQueryBuilder
{
    void HandleSelect();
    void HandleMultipleTableSelectedColumns(List<QueryData> queriesData);
    void HandleJoins(List<Join> joins);
    string GetQuery();
    void ClearQuery();
    void EndQuery();
}