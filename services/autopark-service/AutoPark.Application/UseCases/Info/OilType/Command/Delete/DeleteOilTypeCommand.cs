using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.OilTypes;

public class DeleteOilTypeCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
