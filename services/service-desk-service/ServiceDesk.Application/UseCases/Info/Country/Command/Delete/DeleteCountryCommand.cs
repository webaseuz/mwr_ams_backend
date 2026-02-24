using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Countries;

public class DeleteCountryCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
