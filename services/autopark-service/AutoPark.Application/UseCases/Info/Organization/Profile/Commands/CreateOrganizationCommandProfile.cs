using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Organizations;

public class CreateOrganizationCommandProfile :
    Profile
{
    public CreateOrganizationCommandProfile()
    {
        CreateMap<CreateOrganizationCommand, Organization>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
