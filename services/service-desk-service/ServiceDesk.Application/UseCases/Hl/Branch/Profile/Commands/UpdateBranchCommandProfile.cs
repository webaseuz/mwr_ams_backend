using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Branches;

public class UpdateBranchCommandProfile : Profile
{
    public UpdateBranchCommandProfile()
    {
        CreateMap<UpdateBranchCommand, Branch>();
    }
}