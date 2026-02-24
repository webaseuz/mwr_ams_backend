using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Departments;

public class DepartmentDtoProfile : Profile
{
    public DepartmentDtoProfile()
    {
        //DepartmentDto
        CreateMap<Department, DepartmentDto>();
    }
}