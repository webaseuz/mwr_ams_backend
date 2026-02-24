using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Branches;

class BranchDtoProfile : Profile
{
    public BranchDtoProfile()
    {
        //BranchDto
        CreateMap<Branch, BranchDto>();
    }
}
