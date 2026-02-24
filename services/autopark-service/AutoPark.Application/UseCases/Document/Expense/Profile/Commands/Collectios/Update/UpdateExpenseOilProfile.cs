using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.Expenses;

public class UpdateExpenseOilProfile : Profile
{
    public UpdateExpenseOilProfile()
    {
        CreateMap<UpdateExpenseOilCommand, ExpenseOil>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}
