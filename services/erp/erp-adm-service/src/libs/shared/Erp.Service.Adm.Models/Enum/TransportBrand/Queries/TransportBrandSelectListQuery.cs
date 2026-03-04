using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportBrandSelectListQuery : IRequest<WbSelectList<int>>
{
}