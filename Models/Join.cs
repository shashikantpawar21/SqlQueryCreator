namespace SqlQueryCreator.Models;

using SqlQueryCreator.Enums;

public record Join
{
    public JoinType JoinType;
    public string FromTable;
    public string FromColumn;
    public ComparisonOperator ComparisonOperator;
    public string ToTable;
    public string ToColumn;

    public Join(JoinType join, string toTableName, string toColumnName, ComparisonOperator operation, string fromTableName, string fromColumnName)
    {
        JoinType = join;
        FromTable = fromTableName;
        FromColumn = fromColumnName;
        ComparisonOperator = operation;
        ToTable = toTableName;
        ToColumn = toColumnName;
    }
}