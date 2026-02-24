using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.DriverDocuments;

public class DeletePersonCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
