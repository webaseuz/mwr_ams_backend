using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.MobileAppVersions;

public class DeleteMobileAppVersionCommand : IRequest<SuccessResult<bool>>
{
    public Guid Id { get; set; }
}
