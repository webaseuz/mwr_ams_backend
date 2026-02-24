using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Users;

public class CreateUserCommandProfile : Profile
{
    public CreateUserCommandProfile()
    {
        CreateMap<CreateUserCommand, User>()
            .ForMember(src => src.Person, conf => conf.Ignore());
    }
}
