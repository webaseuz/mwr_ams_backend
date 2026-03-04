using AutoMapper;
using Erp.Integration.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class DriverLicenseProfile : Profile
{
    public DriverLicenseProfile()
    {
        CreateMap<DriverLicenseResponse, DriverLicenseResponseDto>();
        CreateMap<DriverLicenseDocumentModel, DriverLicenseDocumentModelDto>();
        CreateMap<DriverPlaceModel, DriverPlaceModelDto>();
        CreateMap<DriverCategoryModel, DriverCategoryModelDto>();
    }
}
