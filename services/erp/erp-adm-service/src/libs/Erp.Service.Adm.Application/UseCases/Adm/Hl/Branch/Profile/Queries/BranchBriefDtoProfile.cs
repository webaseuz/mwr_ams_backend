using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;


namespace Erp.Service.Adm.Application.UseCases;

class BranchBriefDtoProfile : Profile
{
    public BranchBriefDtoProfile()
    {
        //BranchBriefDto
        CreateMap<Branch, BranchBriefDto>()
            .ForMember(src => src.DistrictName, conf => conf.MapFrom(x => x.District.FullName))
            .ForMember(src => src.RegionName, conf => conf.MapFrom(x => x.Region.FullName))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.FullName));

    }
}
