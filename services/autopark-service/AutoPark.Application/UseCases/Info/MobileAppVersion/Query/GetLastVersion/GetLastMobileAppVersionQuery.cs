using MediatR;

namespace AutoPark.Application.UseCases.MobileAppVersions;

public class GetLastMobileAppVersionQuery :
    IRequest<MobileAppVersionDto>
{ }
