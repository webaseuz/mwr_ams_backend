using MediatR;

namespace Erp.Service.Adm.Models;

public class TrackingInfoCreateCommand : IRequest<bool>
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public long PersonId { get; set; }
    public DateTime DateAt { get; set; }
}
