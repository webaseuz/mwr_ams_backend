
using Bms.WEBASE.Models;

namespace Bms.WEBASE.Helpers;

public interface ICultureHelper
{
    CultureModel DefaultCulture { get; }
    CultureModel CurrentCulture { get; }
    IReadOnlyCollection<CultureModel> Cultures { get; }
}
