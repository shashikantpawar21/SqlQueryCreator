namespace SqlQueryCreator.Models;

using Newtonsoft.Json;
using SqlQueryCreator.Enums;

public class ComparisonFilter
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public ComparisonOperator Operator { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string ColumnName { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string FilterValue { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string NextConditionLinkOperator { get; set; }

}