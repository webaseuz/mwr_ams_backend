using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Organizations;

public class UpdateOrganizationCommandProfile :
    Profile
{
    public UpdateOrganizationCommandProfile()
    {
        CreateMap<UpdateOrganizationCommand, Organization>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
