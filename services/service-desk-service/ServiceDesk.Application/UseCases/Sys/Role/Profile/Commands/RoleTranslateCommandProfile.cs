using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Roles;

public class RoleTranslateCommandProfile : Profile
{
    public RoleTranslateCommandProfile()
    {
        CreateMap<RoleTranslateCommand, RoleTranslate>();
    }
}
