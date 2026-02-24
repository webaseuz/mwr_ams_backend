using Bms.Core.Application.Models;
using Bms.WEBASE.Models;

namespace Bms.Core.Application;

public interface IPagedResultWithActionControls :
    IPagedResult
{
    PagedResultActionControl ActionControls { get; }
}
