using AutoMapper;
namespace AutoPark.Application.UseCases.Expenses;

public class CreateExpenseInsuranceProfile : Profile
{
    public CreateExpenseInsuranceProfile()
    {
        CreateMap<CreateExpenseInsuranceCommand, ExpenseInsurance>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}
