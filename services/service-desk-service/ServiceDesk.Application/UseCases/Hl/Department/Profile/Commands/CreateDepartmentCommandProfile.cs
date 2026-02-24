using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Departments;

public class CreateDepartmentCommandProfile : Profile
{
    public CreateDepartmentCommandProfile()
    {
        CreateMap<CreateDepartmentCommand, Department>();
    }
}