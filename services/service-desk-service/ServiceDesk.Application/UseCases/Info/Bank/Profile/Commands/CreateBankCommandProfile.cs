using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Banks;

public class CreateBankCommandProfile : Profile
{
    public CreateBankCommandProfile()
    {
        CreateMap<CreateBankCommand, Bank>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
