using MediatR;

namespace Erp.Service.Adm.Models;

public class LiquidTypeGetByIdQuery : IRequest<LiquidTypeDto>
{
    public int Id { get; set; }
}
