using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseFileDtoProfile : Profile
{
    public ExpenseFileDtoProfile()
    {
        CreateMap<ExpenseFile, ExpenseFileDto>();
        CreateMap<ExpenseBatteryFile, ExpenseFileDto>();
        CreateMap<ExpenseInsuranceFile, ExpenseFileDto>();
        CreateMap<ExpenseInspectionFile, ExpenseFileDto>();
        CreateMap<ExpenseOilFile, ExpenseFileDto>();
        CreateMap<ExpenseLiquidFile, ExpenseFileDto>();
        CreateMap<ExpenseTireFile, ExpenseFileDto>();
    }
}
