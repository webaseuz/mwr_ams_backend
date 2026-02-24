using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingInsuranceDtoProfile : Profile
{
    public TransportSettingInsuranceDtoProfile()
    {
        int lang = default;

        CreateMap<TransportSettingInsurance, TransportSettingInsuranceDto>()
            .ForMember(src => src.InsuranceTypeName, conf => conf.MapFrom(ent => ent.InsuranceType.Translates.AsQueryable()
                .FirstOrDefault(InsuranceTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.InsuranceType.FullName))
            .ForMember(src => src.ContractorName, conf => conf.MapFrom(ent => ent.Contractor.FullName))
            .ForMember(src => src.ResponsiblePersonName, conf => conf.MapFrom(ent => ent.ResponsiblePerson.FullName));
        ;
    }
}
