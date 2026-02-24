using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Expenses;

public class UpdateExpenseCommandProfile : Profile
{
    public UpdateExpenseCommandProfile()
    {
        CreateMap<UpdateExpenseCommand, Expense>()
            .ForMember(src => src.Batteries, conf => conf.Ignore())
            .ForMember(src => src.Inspections, conf => conf.Ignore())
            .ForMember(src => src.Insurances, conf => conf.Ignore())
            .ForMember(src => src.Liquids, conf => conf.Ignore())
            .ForMember(src => src.Oils, conf => conf.Ignore())
            .ForMember(src => src.Tires, conf => conf.Ignore())
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}
