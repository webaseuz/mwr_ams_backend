using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Users;

public class UpdateUserCommandProfile : Profile
{
    public UpdateUserCommandProfile()
    {
        CreateMap<UpdateUserCommand, User>();
    }
}
