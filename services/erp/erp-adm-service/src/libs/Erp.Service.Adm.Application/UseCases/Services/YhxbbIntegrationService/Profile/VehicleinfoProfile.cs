using AutoMapper;
using Erp.Integration.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class VehicleInfoProfile : Profile
{
    public VehicleInfoProfile()
    {
        CreateMap<VehicleInfoResponse, VehicleInfoResponseDto>();
        CreateMap<VehicleInfoModel, VehicleInfoModelDto>();
        CreateMap<DriverPlaceModel, DriverPlaceModelDto>();
    }
}
