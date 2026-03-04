using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class EmploymentTypeSelectListQuery : IRequest<WbSelectList<int>>
{
}
