using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Branches;

class CreateBranchCommandProfile : Profile
{
    public CreateBranchCommandProfile()
    {
        CreateMap<CreateBranchCommand, Branch>();
    }
}