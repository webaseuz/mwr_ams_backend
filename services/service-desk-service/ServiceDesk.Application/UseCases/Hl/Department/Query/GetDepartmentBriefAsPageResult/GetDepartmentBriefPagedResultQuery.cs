using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Departments;

public class GetDepartmentBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<DepartmentBriefDto>>
{ }