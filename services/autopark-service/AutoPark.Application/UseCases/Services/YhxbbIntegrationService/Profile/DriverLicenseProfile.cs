using AutoMapper;
using AutoPark.Application.UseCases.Drivers;
using AutoPark.Integration.Models;

namespace AutoPark.Application.UseCases;

public class DriverLicenseProfile : Profile
{
    public DriverLicenseProfile()
    {
        // Root
        CreateMap<DriverLicenseResponse, DriverLicenseResponseDto>();

        CreateMap<DriverLicenseDocumentModel, DriverLicenseDocumentModelDto>();
        CreateMap<DriverPlaceModel, DriverPlaceModelDto>();
        CreateMap<DriverCategoryModel, DriverCategoryModelDto>();
    }
}