using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class OrganizationSelectListQuery : IRequest<WbSelectList<int>>
{
}