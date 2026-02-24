using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.DriverPenalties;

public class DriverPenaltyDtoProfile : Profile
{
    public DriverPenaltyDtoProfile()
    {
        int lang = default;

        CreateMap<DriverPenalty, DriverPenaltyDto>()
            .ForMember(src => src.DriverId, exp => exp.MapFrom(ent => ent.Person.Drivers.Any() ? (ent.Person.Drivers.FirstOrDefault().Id) : 0))
            .ForMember(src => src.BranchName, exp => exp.MapFrom(ent => $"{ent.Branch.UniqueCode}-{ent.Branch.FullName}"))
            .ForMember(src => src.TransportModelName, exp => exp.MapFrom(ent => ent.Transport.TransportModel.Translates.AsQueryable().FirstOrDefault(TransportModelTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Transport.TransportModel.FullName))
            .ForMember(src => src.FullName, exp => exp.MapFrom(ent => ent.Person.FullName))
            .ForMember(src => src.IsCritical, exp => exp.MapFrom(ent =>
                ent.DiscountDate.HasValue &&
                ent.DiscountDate.Value >= DateTime.UtcNow.Date &&
                (ent.DiscountDate.Value - DateTime.UtcNow.Date).TotalDays <= 3));
    }
}