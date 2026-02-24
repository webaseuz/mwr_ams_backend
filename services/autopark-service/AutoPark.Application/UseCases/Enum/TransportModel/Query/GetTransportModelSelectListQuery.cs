using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportModels;

public class GetTransportModelSelectListQuery :
    IRequest<SelectList<int>>
{
    public int? TransportBrandId { get; set; }
}