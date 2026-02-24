using AutoMapper;
namespace AutoPark.Application.UseCases.Expenses;

public class UpdateExpenseInsuranceProfile : Profile
{
    public UpdateExpenseInsuranceProfile()
    {
        CreateMap<UpdateExpenseInsuranceCommand, ExpenseInsurance>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}
