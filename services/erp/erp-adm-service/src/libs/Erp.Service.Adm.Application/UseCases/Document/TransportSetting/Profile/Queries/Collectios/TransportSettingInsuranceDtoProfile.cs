using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportSettingInsuranceDtoProfile : CultureProfile
{
    public TransportSettingInsuranceDtoProfile()
    {
        var cultureId = 1;

        CreateMap<TransportSettingInsurance, TransportSettingInsuranceDto>()
            .ForMember(src => src.InsuranceTypeName, conf => conf.MapFrom(ent => ent.InsuranceType.Translates.AsQueryable()
                .FirstOrDefault(InsuranceTypeTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.InsuranceType.FullName))
            .ForMember(src => src.ContractorName, conf => conf.MapFrom(ent => ent.Contractor.FullName))
            .ForMember(src => src.ResponsiblePersonName, conf => conf.MapFrom(ent => ent.ResponsiblePerson.FullName));
    }
}
