using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class DeleteMobileAppVersionCommand : IRequest<SuccessResult<bool>>
{
    public Guid Id { get; set; }
}
