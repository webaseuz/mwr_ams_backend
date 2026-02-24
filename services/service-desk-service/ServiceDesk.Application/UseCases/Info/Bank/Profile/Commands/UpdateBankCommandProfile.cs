using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Banks;

public class UpdateBankCommandProfile : Profile
{
    public UpdateBankCommandProfile()
    {
        CreateMap<UpdateBankCommand, Bank>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
