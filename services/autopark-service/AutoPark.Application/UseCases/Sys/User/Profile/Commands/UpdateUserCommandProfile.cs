using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Users;

public class UpdateUserCommandProfile : Profile
{
    public UpdateUserCommandProfile()
    {
        CreateMap<UpdateUserCommand, User>()
            .ForMember(a => a.Person, x => x.Ignore());
    }
}
