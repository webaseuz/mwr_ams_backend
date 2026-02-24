using MediatR;

namespace AutoPark.Application.UseCases.MobileAppVersions;

public class GetMobileAppVersionQuery :
    IRequest<MobileAppVersionDto>
{ }
