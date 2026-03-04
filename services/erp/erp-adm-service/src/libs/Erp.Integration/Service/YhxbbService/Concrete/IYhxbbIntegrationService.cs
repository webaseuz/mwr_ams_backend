using Erp.Integration.Models;
using Erp.Integration.Models.Yhxbb.VehicleInfo;

namespace Erp.Integration.Service;

public interface IYhxbbIntegrationService
{
    Task<DriverLicenseResponse> GetDriverLicenseInfoAsync(DriverLicenseRequest request);
    Task<VehicleLicenseResponse> GetVehicleLicenseInfoAsync(VehicleLicenseRequest request);
    Task<VehicleInfoResponse> SearchVehicleByPlateNumberAsync(VehicleSearchByPlateNumber request);
    Task<VehicleInfoResponse> SearchVehicleByPnflAsync(VehicleSearchByPinfl request);
    Task<VehicleInfoResponse> SearchVehicleByTinAsync(VehicleSearchByTin request);
}
