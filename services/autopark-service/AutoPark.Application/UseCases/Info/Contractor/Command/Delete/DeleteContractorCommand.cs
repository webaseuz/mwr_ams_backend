using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Info.Contractors;

public class DeleteContractorCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
