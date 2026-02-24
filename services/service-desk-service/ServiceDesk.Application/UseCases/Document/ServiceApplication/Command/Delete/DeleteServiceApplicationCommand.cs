using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class DeleteServiceApplicationCommand :
    IRequest<SuccessResult<bool>>
{
    public long Id { get; set; }
}
