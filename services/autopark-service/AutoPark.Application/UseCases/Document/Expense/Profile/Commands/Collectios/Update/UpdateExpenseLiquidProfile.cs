using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.Expenses;

public class UpdateExpenseLiquidProfile : Profile
{
    public UpdateExpenseLiquidProfile()
    {
        CreateMap<UpdateExpenseLiquidCommand, ExpenseLiquid>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}
