using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationTypeSelectListQuery : IRequest<WbSelectList<int, OrganizationTypeSelectListDto>>
{
}
