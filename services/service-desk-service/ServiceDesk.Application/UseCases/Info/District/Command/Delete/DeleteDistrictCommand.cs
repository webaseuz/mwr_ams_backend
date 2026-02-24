using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Districts;

public class DeleteDistrictCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
