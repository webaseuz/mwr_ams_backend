using AutoMapper;
using AutoPark.Domain;
namespace AutoPark.Application.UseCases.Expenses;

public class UpdateExpenseTireProfile : Profile
{
    public UpdateExpenseTireProfile()
    {
        CreateMap<UpdateExpenseTireCommand, ExpenseTire>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}
