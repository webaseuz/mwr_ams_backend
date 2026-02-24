using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Expenses;

public class CreateExpenseInspectionProfile : Profile
{
    public CreateExpenseInspectionProfile()
    {
        CreateMap<CreateExpenseInspectionCommand, ExpenseInspection>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}
