using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.FuelCards;

public class FuelCardDtoProfile :
    Profile
{
    public FuelCardDtoProfile()
    {
        int lang = default;
        CreateMap<FuelCard, FuelCardDto>()
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.ShortName))
            .ForMember(src => src.PlasticCardTypeName, conf => conf.MapFrom(ent => ent.PlasticCardType.Translates.AsQueryable().FirstOrDefault(PlasticCardTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.PlasticCardType.ShortName))
            .ForMember(src => src.DriverName, conf => conf.MapFrom(ent => ent.Driver.Person.FullName ?? ent.Driver.Person.FullName))
            .ForMember(src => src.TransportStateNumber, conf => conf.MapFrom(ent => ent.Transport.StateNumber))
            .ForMember(src => src.ExpireAt, conf => conf.MapFrom(src => src.ExpireAt.HasValue ? src.ExpireAt.Value.ToString("MM/yy") : string.Empty))

            .ForMember(src => src.TransportModelName, conf => conf.MapFrom(ent => ent.Transport.TransportModel.Translates.AsQueryable()
                .FirstOrDefault(TransportModelTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Transport.TransportModel.FullName))
            ;
    }
}
