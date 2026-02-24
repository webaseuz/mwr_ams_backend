using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Departments;

public class DepartmentTranslateCommand :
    TranslateCommand<DepartmentTranslateCommand, DepartmentTranslate, TranslateColumn>
{ }
