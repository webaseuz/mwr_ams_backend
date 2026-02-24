using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.Expenses;

public class CreateExpenseTireProfile : Profile
{
    public CreateExpenseTireProfile()
    {
        CreateMap<CreateExpenseTireCommand, ExpenseTire>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}
