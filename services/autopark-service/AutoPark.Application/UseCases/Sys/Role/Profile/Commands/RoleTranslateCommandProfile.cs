using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Roles;

public class RoleTranslateCommandProfile : Profile
{
    public RoleTranslateCommandProfile()
    {
        CreateMap<RoleTranslateCommand, RoleTranslate>();
    }
}
