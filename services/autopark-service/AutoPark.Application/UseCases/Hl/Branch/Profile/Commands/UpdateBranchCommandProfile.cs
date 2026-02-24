using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Branches;

public class UpdateBranchCommandProfile : Profile
{
    public UpdateBranchCommandProfile()
    {
        CreateMap<UpdateBranchCommand, Branch>();
    }
}