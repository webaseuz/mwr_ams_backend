using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportModelSelectListQuery : IRequest<WbSelectList<int>>
{
    public int? TransportBrandId { get; set; }
}