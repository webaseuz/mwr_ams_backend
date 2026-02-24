using MediatR;

namespace AutoPark.Application.UseCases.MobileAppVersions;

public class GetMobileAppVersionQueryHandler :
    IRequestHandler<GetMobileAppVersionQuery, MobileAppVersionDto>
{
    public Task<MobileAppVersionDto> Handle(
        GetMobileAppVersionQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new MobileAppVersionDto());
}
