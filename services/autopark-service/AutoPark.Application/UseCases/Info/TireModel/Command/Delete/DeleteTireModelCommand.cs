using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TireModels;

public class DeleteTireModelCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
