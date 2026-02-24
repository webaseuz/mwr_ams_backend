using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Expenses;

public class UpdateExpenseBatteryProfile : Profile
{
    public UpdateExpenseBatteryProfile()
    {
        CreateMap<UpdateExpenseBatteryCommand, ExpenseBattery>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}
