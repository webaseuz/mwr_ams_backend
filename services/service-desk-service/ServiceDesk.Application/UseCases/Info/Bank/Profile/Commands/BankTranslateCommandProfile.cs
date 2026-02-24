using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Banks;

public class BankTranslateCommandProfile : Profile
{
    public BankTranslateCommandProfile()
    {
        CreateMap<BankTranslateCommand, BankTranslate>();
    }
}
