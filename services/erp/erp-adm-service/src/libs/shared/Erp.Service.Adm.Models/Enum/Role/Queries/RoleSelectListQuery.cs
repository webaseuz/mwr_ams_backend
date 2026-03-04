using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class RoleSelectListQuery : IRequest<WbSelectList<int>>
{
}