using AutoPark.Integration.Models;
using AutoPark.Integration.Models.Yhxbb.VehicleInfo;

namespace AutoPark.Integration.Service;

public interface IYhxbbIntegrationService
{
    Task<DriverLicenseResponse> GetDriverLicenseInfoAsync(DriverLicenseRequest request);
    Task<VehicleLicenseResponse> GetVehicleLicenseInfoAsync(VehicleLicenseRequest request);
    Task<VehicleInfoResponse> SearchVehicleByPlateNumberAsync(VehicleSearchByPlateNumber request);
    Task<VehicleInfoResponse> SearchVehicleByPnflAsync(VehicleSearchByPinfl request);
    Task<VehicleInfoResponse> SearchVehicleByTinAsync(VehicleSearchByTin request);
}
