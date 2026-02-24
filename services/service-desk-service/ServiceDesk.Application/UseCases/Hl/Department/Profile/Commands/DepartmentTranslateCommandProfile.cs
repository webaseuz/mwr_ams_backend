using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Departments;

public class DepartmentTranslateCommandProfile : Profile
{
    public DepartmentTranslateCommandProfile()
    {
        CreateMap<DepartmentTranslateCommand, DepartmentTranslate>();
    }
}
