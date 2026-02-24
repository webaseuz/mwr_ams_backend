using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.MobileAppVersions;

public class UpdateMobileAppVersionCommandProfile :
    Profile
{
    public UpdateMobileAppVersionCommandProfile()
    {
        CreateMap<UpdateMobileAppVersionCommand, MobileAppVersion>();
    }
}
