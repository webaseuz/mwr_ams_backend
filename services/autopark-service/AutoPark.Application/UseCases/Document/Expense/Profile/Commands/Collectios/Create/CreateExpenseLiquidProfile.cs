using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.Expenses;

public class CreateExpenseLiquidProfile : Profile
{
    public CreateExpenseLiquidProfile()
    {
        CreateMap<CreateExpenseLiquidCommand, ExpenseLiquid>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}
