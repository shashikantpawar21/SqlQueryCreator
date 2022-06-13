namespace SqlQueryCreator.Models;


public class WhereClause
{
    public List<ComparisonFilter>? ComparisonFilters { get; set; }
    public List<RangeFilter>? RangeFilters { get; set; }
}