using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Info.Contractors;

public class CreateContractorCommandProfile : Profile
{
    public CreateContractorCommandProfile()
    {
        CreateMap<CreateContractorCommand, Contractor>();
    }
}
