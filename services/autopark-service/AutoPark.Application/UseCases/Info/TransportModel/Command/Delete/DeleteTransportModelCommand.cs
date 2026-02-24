using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportModels;

public class DeleteTransportModelCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
