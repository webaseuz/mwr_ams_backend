using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.Expenses;

public class CreateExpenseOilProfile : Profile
{
    public CreateExpenseOilProfile()
    {
        CreateMap<CreateExpenseOilCommand, ExpenseOil>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}
