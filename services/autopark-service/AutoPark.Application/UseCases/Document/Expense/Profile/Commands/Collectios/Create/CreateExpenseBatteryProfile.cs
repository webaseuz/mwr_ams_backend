using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Expenses;

public class CreateExpenseBatteryProfile : Profile
{
    public CreateExpenseBatteryProfile()
    {
        CreateMap<CreateExpenseBatteryCommand, ExpenseBattery>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}
