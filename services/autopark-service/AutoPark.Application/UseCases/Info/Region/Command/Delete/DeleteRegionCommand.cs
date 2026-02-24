using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Regions;

public class DeleteRegionCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
