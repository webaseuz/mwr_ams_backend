using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportModelFileSelectListQuery : IRequest<WbSelectList<Guid>>
{
    public int TransportModelId { get; set; }
    public int TransportColorId { get; set; }
}