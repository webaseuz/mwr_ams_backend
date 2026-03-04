using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportColorSelectListQuery : IRequest<WbSelectList<int>>
{
}