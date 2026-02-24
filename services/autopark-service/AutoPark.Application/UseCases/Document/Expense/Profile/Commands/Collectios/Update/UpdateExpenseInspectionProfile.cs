using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.Expenses;

public class UpdateExpenseInspectionProfile : Profile
{
    public UpdateExpenseInspectionProfile()
    {
        CreateMap<UpdateExpenseInspectionCommand, ExpenseInspection>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}
