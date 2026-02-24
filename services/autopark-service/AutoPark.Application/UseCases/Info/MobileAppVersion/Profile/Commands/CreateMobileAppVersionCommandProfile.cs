using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.MobileAppVersions;

public class CreateMobileAppVersionCommandProfile :
    Profile
{
    public CreateMobileAppVersionCommandProfile()
    {
        CreateMap<CreateMobileAppVersionCommand, MobileAppVersion>();
    }
}
