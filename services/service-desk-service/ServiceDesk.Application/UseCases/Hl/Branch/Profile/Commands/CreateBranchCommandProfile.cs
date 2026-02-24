using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Branches;

class CreateBranchCommandProfile : Profile
{
    public CreateBranchCommandProfile()
    {
        CreateMap<CreateBranchCommand, Branch>();
    }
}