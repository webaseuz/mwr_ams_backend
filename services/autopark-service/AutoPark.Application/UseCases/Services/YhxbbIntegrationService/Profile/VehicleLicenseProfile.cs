using AutoMapper;
using AutoPark.Application.UseCases.Drivers;
using AutoPark.Integration.Models;
using AutoPark.Integration.Models.Yhxbb.VehicleInfo;

namespace AutoPark.Application.UseCases;

public class VehicleLicenseProfile : Profile
{
    public VehicleLicenseProfile()
    {
        // Root
        CreateMap<VehicleLicenseResponse, VehicleLicenseResponseDto>();

        CreateMap<VehicleInfoModel, VehicleInfoModelDto>();
        CreateMap<DriverPlaceModel, DriverPlaceModelDto>();
    }
}