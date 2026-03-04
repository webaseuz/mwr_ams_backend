using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class PositionSelectListQuery : IRequest<WbSelectList<int>>
{
}
