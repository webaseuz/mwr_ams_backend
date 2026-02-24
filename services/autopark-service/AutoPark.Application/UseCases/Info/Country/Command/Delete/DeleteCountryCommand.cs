using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Countries;

public class DeleteCountryCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
