using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Info.Contractors;

public class CreateContractorCommandProfile : Profile
{
    public CreateContractorCommandProfile()
    {
        CreateMap<CreateContractorCommand, Contractor>();
    }
}
