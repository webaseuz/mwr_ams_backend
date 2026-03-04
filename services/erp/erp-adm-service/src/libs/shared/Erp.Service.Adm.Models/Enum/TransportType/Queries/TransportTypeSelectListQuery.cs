using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportTypeSelectListQuery : IRequest<WbSelectList<int>>
{
}