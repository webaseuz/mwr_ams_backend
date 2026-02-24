using GenericServices;
using Newtonsoft.Json;
using WEBASE.LogSdk.DAL.EfClasses;

namespace WEBASE.LogSdk.BLL.Services;
public class ErrorScopeDto : ErrorScopeBase, ILinkToEntity<ErrorScope>
{
    public int Count { get; set; }

    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? LastOccuredAt { get; set; }

    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? FixedAt { get; set; }

    public bool CanFix { get; set; }
}