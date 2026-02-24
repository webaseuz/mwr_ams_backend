using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class UpdateMobileAppVersionCommandProfile :
    Profile
{
    public UpdateMobileAppVersionCommandProfile()
    {
        CreateMap<UpdateMobileAppVersionCommand, MobileAppVersion>();
    }
}
