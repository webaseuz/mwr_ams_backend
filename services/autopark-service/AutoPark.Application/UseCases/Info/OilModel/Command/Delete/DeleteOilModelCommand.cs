using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.OilModels;

public class DeleteOilModelCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
