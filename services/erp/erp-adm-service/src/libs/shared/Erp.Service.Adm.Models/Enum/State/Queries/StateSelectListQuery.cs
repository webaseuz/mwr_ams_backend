using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class StateSelectListQuery : IRequest<WbSelectList<int>>
{
}