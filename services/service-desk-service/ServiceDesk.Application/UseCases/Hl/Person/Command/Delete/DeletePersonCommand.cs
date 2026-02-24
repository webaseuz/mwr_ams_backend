using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Persons;

public class DeletePersonCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
