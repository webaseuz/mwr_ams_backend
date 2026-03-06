using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class ExpenseDtoMapping : CultureProfile
{
    public ExpenseDtoMapping()
    {
        var cultureId = 1;

        CreateMap<ExpenseFile, ExpenseFileDto>();
        CreateMap<ExpenseBatteryFile, ExpenseFileDto>();
        CreateMap<ExpenseInspectionFile, ExpenseFileDto>();
        CreateMap<ExpenseInsuranceFile, ExpenseFileDto>();
        CreateMap<ExpenseLiquidFile, ExpenseFileDto>();
        CreateMap<ExpenseOilFile, ExpenseFileDto>();
        CreateMap<ExpenseTireFile, ExpenseFileDto>();

        CreateMap<ExpenseBattery, ExpenseBatteryDto>()
            .ForMember(x => x.BatteryTypeName, x => x.MapFrom(ent =>
                ent.BatteryType.Translates.AsQueryable()
                    .FirstOrDefault(BatteryTypeTranslate.GetExpr(TranslateColumn.full_name, cultureId))
                    .TranslateText ?? ent.BatteryType.FullName));

        CreateMap<ExpenseInspection, ExpenseInspectionDto>()
            .ForMember(x => x.InspectionTypeName, x => x.MapFrom(ent =>
                ent.InspectionType.Translates.AsQueryable()
                    .FirstOrDefault(InspectionTypeTranslate.GetExpr(TranslateColumn.full_name, cultureId))
                    .TranslateText ?? ent.InspectionType.FullName))
            .ForMember(x => x.TotalPrice, x => x.Ignore());

        CreateMap<ExpenseInsurance, ExpenseInsuranceDto>()
            .ForMember(x => x.InsuranceTypeName, x => x.MapFrom(ent =>
                ent.InsuranceType.Translates.AsQueryable()
                    .FirstOrDefault(InsuranceTypeTranslate.GetExpr(TranslateColumn.full_name, cultureId))
                    .TranslateText ?? ent.InsuranceType.FullName))
            .ForMember(x => x.ContractorName, x => x.MapFrom(ent => ent.Contractor.FullName))
            .ForMember(x => x.Details, x => x.Ignore())
            .ForMember(x => x.TotalPrice, x => x.Ignore());

        CreateMap<ExpenseLiquid, ExpenseLiquidDto>()
            .ForMember(x => x.LiquidTypeName, x => x.MapFrom(ent =>
                ent.LiquidType.Translates.AsQueryable()
                    .FirstOrDefault(LiquidTypeTranslate.GetExpr(TranslateColumn.full_name, cultureId))
                    .TranslateText ?? ent.LiquidType.FullName));

        CreateMap<ExpenseOil, ExpenseOilDto>()
            .ForMember(x => x.OilTypeName, x => x.MapFrom(ent =>
                ent.OilType.Translates.AsQueryable()
                    .FirstOrDefault(OilTypeTranslate.GetExpr(TranslateColumn.full_name, cultureId))
                    .TranslateText ?? ent.OilType.FullName))
            .ForMember(x => x.OilModelName, x => x.MapFrom(ent =>
                ent.OilModel.Translates.AsQueryable()
                    .FirstOrDefault(OilModelTranslate.GetExpr(TranslateColumn.full_name, cultureId))
                    .TranslateText ?? ent.OilModel.FullName));

        CreateMap<ExpenseTire, ExpenseTireDto>()
            .ForMember(x => x.TireSizeName, x => x.MapFrom(ent =>
                $"{ent.TireSize.Width}/{ent.TireSize.Height}R{ent.TireSize.Radius}"))
            .ForMember(x => x.TireModelName, x => x.MapFrom(ent =>
                ent.TireModel.Translates.AsQueryable()
                    .FirstOrDefault(TireModelTranslate.GetExpr(TranslateColumn.full_name, cultureId))
                    .TranslateText ?? ent.TireModel.FullName));

        CreateMap<Expense, ExpenseDto>()
            .ForMember(x => x.TransportInfo, x => x.MapFrom(ent =>
                $"{ent.Transport.StateCode} {ent.Transport.StateNumber}"))
            .ForMember(x => x.DriverName, x => x.MapFrom(ent => ent.Driver.Person.FullName))
            .ForMember(x => x.BranchName, x => x.MapFrom(ent => ent.Branch.FullName))
            .ForMember(x => x.StatusName, x => x.MapFrom(ent =>
                ent.Status.Translates.AsQueryable()
                    .FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name, cultureId))
                    .TranslateText ?? ent.Status.FullName))
            .ForMember(x => x.CanCreateForAllBranch, x => x.Ignore())
            .ForMember(x => x.CanInvoice, x => x.Ignore());
    }
}
