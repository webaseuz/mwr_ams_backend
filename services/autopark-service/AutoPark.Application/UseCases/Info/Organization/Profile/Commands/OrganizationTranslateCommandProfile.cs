using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Organizations;

public class TransportOrganizationCommandProfile :
    Profile
{
    public TransportOrganizationCommandProfile()
    {
        CreateMap<OrganizationTranslateCommand, OrganizationTranslate>();
    }
}
