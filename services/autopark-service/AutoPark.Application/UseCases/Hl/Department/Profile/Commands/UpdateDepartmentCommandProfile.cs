using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Departments;

class UpdateDepartmentCommandProfile : Profile
{
    public UpdateDepartmentCommandProfile()
    {
        CreateMap<UpdateDepartmentCommand, Department>();
    }
}