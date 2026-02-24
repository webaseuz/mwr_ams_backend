using Bms.WEBASE.Models;
using Newtonsoft.Json;
using System.Globalization;

namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingDto :
    IHaveIdProp<long>
{
    public long Id { get; set; }
    public string DocNumber { get; set; } = null!;
    public DateTime DocDate { get; set; }
    public int TransportId { get; set; }
    public long? ManagerId { get; set; }
    public string TransportName { get; set; }
    public string TransportModelName { get; set; }
    public int TransportModelId { get; set; }
    public int TransportColorId { get; set; }
    public string TransportColorName { get; set; }
    public int OrganizationId { get; set; }
    public int BranchId { get; set; }
    public string BranchName { get; set; }
    public int DriverId { get; set; }
    public string DriverName { get; set; }
    public string LicenseNumber { get; set; } = null!;
    public int WorkedHours { get; set; }
    [JsonConverter(typeof(DateTimeMinValueAsNullConverter))]
    public DateTime LicenseEndAt { get; set; }
    public string PoaNumber { get; set; } = null!;
    [JsonConverter(typeof(DateTimeMinValueAsNullConverter))]
    public DateTime PoaEndAt { get; set; }
    public string MedCertNumber { get; set; } = null!;
    [JsonConverter(typeof(DateTimeMinValueAsNullConverter))]
    public DateTime MedCertEndAt { get; set; }
    public string ManagerFullName { get; set; }
    public decimal LoadCapacity { get; set; }
    public int SeatCount { get; set; }
    public decimal OdometrIndicator { get; set; }
    public string FuelCardNumber { get; set; } = null!;
    public long ResponsiblePersonId { get; set; }
    public string ResponsiblePersonName { get; set; }
    public string Message { get; set; }
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool CanCreateForAllBranch { get; set; }

    public List<TransportSettingBatteryDto> Batteries { get; set; } = new();
    public List<TransportSettingFuelDto> Fuels { get; set; } = new();
    public List<TransportSettingInspectionDto> Inspections { get; set; } = new();
    public List<TransportSettingInsuranceDto> Insurances { get; set; } = new();
    public List<TransportSettingLiquidDto> Liquids { get; set; } = new();
    public List<TransportSettingOilDto> Oils { get; set; } = new();
    public List<TransportSettingTireDto> Tires { get; set; } = new();
    public List<TransportSettingFileDto> Files { get; set; } = new();
}


public class DateTimeMinValueAsNullConverter : JsonConverter<DateTime>
{
    public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value == null || string.IsNullOrEmpty(reader.Value.ToString()))
            return DateTime.MinValue;

        return DateTime.Parse(reader.Value.ToString(), CultureInfo.InvariantCulture);
    }

    public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
    {
        if (value == DateTime.MinValue)
            writer.WriteNull();
        else
            writer.WriteValue(value);
    }
}