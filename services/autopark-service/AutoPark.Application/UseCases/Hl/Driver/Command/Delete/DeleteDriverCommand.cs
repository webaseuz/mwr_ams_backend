using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Drivers;

public class DeleteDriverCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
