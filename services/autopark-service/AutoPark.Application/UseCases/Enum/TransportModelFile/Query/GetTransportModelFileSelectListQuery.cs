using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportModelFiles;

public class GetTransportModelFileSelectListQuery :
    IRequest<SelectList<Guid>>
{
    public int TransportModelId { get; set; }
    public int TransportColorId { get; set; }
}
