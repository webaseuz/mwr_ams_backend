using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Departments;

class UpdateDepartmentCommandProfile : Profile
{
    public UpdateDepartmentCommandProfile()
    {
        CreateMap<UpdateDepartmentCommand, Department>();
    }
}