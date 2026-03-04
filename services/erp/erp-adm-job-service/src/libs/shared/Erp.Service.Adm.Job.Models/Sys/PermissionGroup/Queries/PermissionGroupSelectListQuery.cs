using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class PermissionGroupSelectListQuery : IRequest<WbSelectList<int>>
{
}
