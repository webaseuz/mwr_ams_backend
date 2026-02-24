using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Info.Contractors;

public class UpdateContractorCommandProfile : Profile
{
    public UpdateContractorCommandProfile()
    {
        CreateMap<UpdateContractorCommand, Contractor>();
    }
}
