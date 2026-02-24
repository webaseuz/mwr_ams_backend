namespace Bms.WEBASE.Models;

public interface ISortFilterOptions
{
    string Search { get; }
    string SortBy { get; }
    string OrderType { get; }
    bool HasSort();
    bool HasSearch();
}
