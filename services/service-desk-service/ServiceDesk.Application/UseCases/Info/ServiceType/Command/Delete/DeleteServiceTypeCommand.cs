using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class DeleteServiceTypeCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}