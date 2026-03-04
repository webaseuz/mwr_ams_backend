using MediatR;

namespace Erp.Service.Adm.Models;

public class PresentTrackingInfoCreateCommand : IRequest<bool>
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}
