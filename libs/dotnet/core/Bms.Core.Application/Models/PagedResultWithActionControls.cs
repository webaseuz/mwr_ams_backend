using Bms.Core.Application.Models;
using Bms.WEBASE.Models;

namespace Bms.Core.Application;

public class PagedResultWithActionControls<TRow> :
    PagedResult<TRow>,
    IPagedResultWithActionControls
{
    public PagedResultWithActionControls()
    { }

    public PagedResultWithActionControls(int page,
                                         int pageSize,
                                         long total,
                                         PagedResultActionControl actionControls,
                                         IEnumerable<TRow> rows) :
        base(page,
             pageSize,
             total,
             rows)
    {
        ActionControls = actionControls;
    }

    public PagedResultWithActionControls(IPagedResultWithActionControls pagedResult,
                                         IEnumerable<TRow> rows)
        : this(pagedResult.Page,
               pagedResult.PageSize,
               pagedResult.Total,
               pagedResult.ActionControls,
               rows)
    { }

    public PagedResultActionControl ActionControls { get; set; }
}
