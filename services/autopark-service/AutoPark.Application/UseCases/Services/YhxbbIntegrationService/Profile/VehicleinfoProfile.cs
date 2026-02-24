using AutoMapper;
using AutoPark.Integration.Models;

namespace AutoPark.Application.UseCases;

public class VehicleInfoProfile : Profile
{
    public VehicleInfoProfile()
    {
        // Root
        CreateMap<VehicleInfoResponse, VehicleInfoResponseDto>();

        CreateMap<VehicleInfoModel, VehicleInfoModelDto>();
        CreateMap<DriverPlaceModel, DriverPlaceModelDto>();
    }
}