using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class DriverPenaltyDtoProfile : Profile
{
    public DriverPenaltyDtoProfile()
    {
        CreateMap<DriverPenalty, DriverPenaltyDto>()
            .ForMember(dest => dest.DriverId, conf => conf.MapFrom(ent =>
                ent.Person.Drivers.Select(d => d.Id).FirstOrDefault()))
            .ForMember(dest => dest.FullName, conf => conf.MapFrom(ent => ent.Person.FullName))
            .ForMember(dest => dest.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
            .ForMember(dest => dest.TransportModelName, conf => conf.MapFrom(ent =>
                ent.Transport.TransportModel.FullName))
            .ForMember(dest => dest.IsCritical, conf => conf.MapFrom(ent =>
                ent.DiscountDate.HasValue &&
                ent.DiscountDate.Value >= DateTime.UtcNow.Date &&
                (ent.DiscountDate.Value - DateTime.UtcNow.Date).TotalDays <= 3));
    }
}
