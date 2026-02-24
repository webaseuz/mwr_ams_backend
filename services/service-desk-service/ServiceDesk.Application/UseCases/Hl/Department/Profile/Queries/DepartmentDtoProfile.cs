using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Departments;

public class DepartmentDtoProfile : Profile
{
    public DepartmentDtoProfile()
    {
        //DepartmentDto
        CreateMap<Department, DepartmentDto>();
    }
}