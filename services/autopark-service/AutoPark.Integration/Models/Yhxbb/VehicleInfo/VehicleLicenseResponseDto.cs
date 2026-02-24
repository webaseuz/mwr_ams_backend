using Newtonsoft.Json;

namespace AutoPark.Integration.Models;

public class VehicleLicenseResponseDto
{
    public int Result { get; set; }

    public string Comment { get; set; }

    public string Pinfl { get; set; }

    public string OwnerName { get; set; }

    public int OwnerType { get; set; }

    public string OrganizationInn { get; set; }

    public List<VehicleInfoModelDto> Vehicles { get; set; }
}