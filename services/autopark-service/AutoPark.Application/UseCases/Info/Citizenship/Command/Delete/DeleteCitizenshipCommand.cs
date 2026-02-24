using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Citizenships;

public class DeleteCitizenshipCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
