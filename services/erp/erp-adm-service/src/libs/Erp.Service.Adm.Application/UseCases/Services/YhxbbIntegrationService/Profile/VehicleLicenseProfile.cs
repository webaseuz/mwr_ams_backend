using AutoMapper;
using Erp.Integration.Models;
using Erp.Integration.Models.Yhxbb.VehicleInfo;

namespace Erp.Service.Adm.Application.UseCases;

public class VehicleLicenseProfile : Profile
{
    public VehicleLicenseProfile()
    {
        CreateMap<VehicleLicenseResponse, VehicleLicenseResponseDto>();
        CreateMap<VehicleInfoModel, VehicleInfoModelDto>();
        CreateMap<DriverPlaceModel, DriverPlaceModelDto>();
    }
}
