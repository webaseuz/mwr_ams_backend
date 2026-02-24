using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Departments;

public class DepartmentTranslateCommand :
    TranslateCommand<DepartmentTranslateCommand, DepartmentTranslate, TranslateColumn>
{ }
