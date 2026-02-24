using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TireSizes;

public class DeleteTireSizeCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
