namespace SqlQueryCreator.Models;

using Newtonsoft.Json;

public class QueryData
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tableName")]
    public string TableName { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "selectedColumns")]
    public string[]? SelectedColumns { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "whereClause")]
    public WhereClause WhereClause { get; set; }

}