using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseInsuranceDtoProfile : Profile
{
    public ExpenseInsuranceDtoProfile()
    {
        int lang = default;

        CreateMap<ExpenseInsurance, ExpenseInsuranceDto>()
            .ForMember(src => src.InsuranceTypeName, conf => conf.MapFrom(ent => ent.InsuranceType.Translates.AsQueryable()
                .FirstOrDefault(InsuranceTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.InsuranceType.FullName))
            .ForMember(src => src.ContractorName, conf => conf.MapFrom(ent => ent.Contractor.FullName))
            .ForMember(src => src.Files, conf => conf.MapFrom(ent => ent.Files));
        ;
    }
}
