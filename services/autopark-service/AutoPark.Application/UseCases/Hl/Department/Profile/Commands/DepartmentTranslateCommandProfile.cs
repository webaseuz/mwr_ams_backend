using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Departments;

public class DepartmentTranslateCommandProfile : Profile
{
    public DepartmentTranslateCommandProfile()
    {
        CreateMap<DepartmentTranslateCommand, DepartmentTranslate>();
    }
}
