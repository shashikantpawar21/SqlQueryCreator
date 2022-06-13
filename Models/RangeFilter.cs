namespace SqlQueryCreator.Models;

using Newtonsoft.Json;
using SqlQueryCreator.Enums;

public class RangeFilter
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public RangeOperator Operator { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string ColumnName { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public List<string> FilterValues { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string NextConditionLinkOperator { get; set; }

}