using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Organizations;

public class CreateOrganizationCommandProfile : 
	Profile
{
    public CreateOrganizationCommandProfile()
    {
        CreateMap<CreateOrganizationCommand, Organization>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
