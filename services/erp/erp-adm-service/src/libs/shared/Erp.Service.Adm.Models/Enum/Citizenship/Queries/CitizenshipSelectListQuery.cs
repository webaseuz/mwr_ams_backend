using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class CitizenshipSelectListQuery : IRequest<WbSelectList<int>>
{
}