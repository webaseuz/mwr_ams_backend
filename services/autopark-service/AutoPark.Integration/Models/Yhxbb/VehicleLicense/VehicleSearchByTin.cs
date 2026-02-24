using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AutoPark.Integration.Models;

public class VehicleSearchByTin
{
    [JsonProperty("pTin")]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "TIN uzunligi 9 bo‘lishi kerak")]
    public string Tin { get; set; }
}
