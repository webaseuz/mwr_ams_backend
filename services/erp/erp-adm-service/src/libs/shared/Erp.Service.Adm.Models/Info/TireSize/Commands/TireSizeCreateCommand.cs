using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TireSizeCreateCommand : IRequest<WbHaveId<int>>
{
    public string? OrderCode { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Radius { get; set; }
    public int StateId { get; set; }
}
