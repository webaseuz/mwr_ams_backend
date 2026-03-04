using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class DriverPenaltyBriefDtoProfile : Profile
{
    public DriverPenaltyBriefDtoProfile()
    {
        CreateMap<DriverPenalty, DriverPenaltyBriefDto>()
            .ForMember(dest => dest.DriverId, conf => conf.MapFrom(ent =>
                ent.Person.Drivers.Select(d => d.Id).FirstOrDefault()))
            .ForMember(dest => dest.FullName, conf => conf.MapFrom(ent => ent.Person.FullName))
            .ForMember(dest => dest.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
            .ForMember(dest => dest.RegionId, conf => conf.MapFrom(ent => ent.Branch.RegionId))
            .ForMember(dest => dest.TransportModelName, conf => conf.MapFrom(ent =>
                ent.Transport.TransportModel.FullName))
            .ForMember(dest => dest.IsCritical, conf => conf.MapFrom(ent =>
                ent.DiscountDate.HasValue &&
                ent.DiscountDate.Value >= DateTime.UtcNow.Date &&
                (ent.DiscountDate.Value - DateTime.UtcNow.Date).TotalDays <= 3))
            .ForMember(dest => dest.CanPay, conf => conf.Ignore());
    }
}
