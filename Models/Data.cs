namespace SqlQueryCreator.Models;

using Newtonsoft.Json;

public class Data
{
    public List<QueryData>? QueryData { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "join")]
    public List<Join> Joins { get; set; }
}