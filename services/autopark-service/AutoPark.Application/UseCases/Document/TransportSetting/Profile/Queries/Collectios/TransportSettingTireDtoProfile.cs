using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingTireDtoProfile : Profile
{
    public TransportSettingTireDtoProfile()
    {
        int lang = default;
        CreateMap<TransportSettingTire, TransportSettingTireDto>()
            .ForMember(src => src.TireModelName, conf => conf.MapFrom(ent => ent.TireModel.Translates.AsQueryable()
            .FirstOrDefault(TireModelTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.TireModel.FullName))
            .ForMember(src => src.Size, conf => conf.MapFrom(ent => $"{ent.TireSize.Height}/{ent.TireSize.Width} R{ent.TireSize.Radius}"));

    }
}
