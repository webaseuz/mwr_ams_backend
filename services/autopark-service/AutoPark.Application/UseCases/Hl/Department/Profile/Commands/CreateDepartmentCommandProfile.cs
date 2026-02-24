using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Departments;

public class CreateDepartmentCommandProfile : Profile
{
    public CreateDepartmentCommandProfile()
    {
        CreateMap<CreateDepartmentCommand, Department>();
    }
}