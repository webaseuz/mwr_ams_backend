using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class CreateMobileAppVersionCommandProfile :
    Profile
{
    public CreateMobileAppVersionCommandProfile()
    {
        CreateMap<CreateMobileAppVersionCommand, MobileAppVersion>();
    }
}
