using SqlQueryCreator.Models;

namespace SqlQueryCreator.Services
{
    public interface IQueryService
    {
        string BuildSqlQuery(Data data);
    }
}