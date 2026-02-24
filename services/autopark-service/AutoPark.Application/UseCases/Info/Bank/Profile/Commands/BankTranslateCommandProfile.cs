using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Banks;

public class BankTranslateCommandProfile : Profile
{
    public BankTranslateCommandProfile()
    {
        CreateMap<BankTranslateCommand, BankTranslate>();
    }
}
