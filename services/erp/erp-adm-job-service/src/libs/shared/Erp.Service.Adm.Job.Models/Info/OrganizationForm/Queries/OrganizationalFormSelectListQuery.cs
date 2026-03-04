using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationalFormSelectListQuery : IRequest<WbSelectList<int>>
{
}
