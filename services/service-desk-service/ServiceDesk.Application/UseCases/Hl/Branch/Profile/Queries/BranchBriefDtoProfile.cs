using AutoMapper;


namespace ServiceDesk.Application.UseCases.Branches;

class BranchBriefDtoProfile : Profile
{
    public BranchBriefDtoProfile()
    {
        //BranchBriefDto
        CreateMap<Domain.Branch, BranchBriefDto>()
            .ForMember(src => src.DistrictName, conf => conf.MapFrom(x => x.District.FullName))
            .ForMember(src => src.RegionName, conf => conf.MapFrom(x => x.Region.FullName))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.FullName));

    }
}