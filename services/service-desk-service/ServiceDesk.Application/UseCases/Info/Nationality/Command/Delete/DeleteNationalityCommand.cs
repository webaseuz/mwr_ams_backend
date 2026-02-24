using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Nationalities;

public class DeleteNationalityCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
