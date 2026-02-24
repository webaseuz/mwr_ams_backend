using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Organizations;

public class TransportOrganizationCommandProfile : 
	Profile
{
    public TransportOrganizationCommandProfile()
    {
        CreateMap<OrganizationTranslateCommand, OrganizationTranslate>();
    }
}
