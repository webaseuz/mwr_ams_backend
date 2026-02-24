using Bms.WEBASE.Helpers;
using Newtonsoft.Json;

namespace AutoPark.Application.UseCases.TrackingInfos;

public class TrackingInfoBriefDto
{
    public long Id { get; set; }
    public long PersonId { get; set; }
    public string PersonName { get; set; } = string.Empty;
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    [JsonConverter(typeof(WbDateTimeConverter))]
    public DateTime DateAt { get; set; }
}
