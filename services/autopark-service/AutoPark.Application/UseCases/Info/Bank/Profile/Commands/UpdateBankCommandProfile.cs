using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Banks;

public class UpdateBankCommandProfile : Profile
{
    public UpdateBankCommandProfile()
    {
        CreateMap<UpdateBankCommand, Bank>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
