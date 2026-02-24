using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Info.Contractors;

public class UpdateContractorCommandProfile : Profile
{
    public UpdateContractorCommandProfile()
    {
        CreateMap<UpdateContractorCommand, Contractor>();
    }
}
