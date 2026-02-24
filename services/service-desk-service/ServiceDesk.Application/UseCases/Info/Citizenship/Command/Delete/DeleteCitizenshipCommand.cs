using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class DeleteCitizenshipCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
