using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Branches;

class BranchDtoProfile : Profile
{
    public BranchDtoProfile()
    {
        //BranchDto
        CreateMap<Branch, BranchDto>();
    }
}
