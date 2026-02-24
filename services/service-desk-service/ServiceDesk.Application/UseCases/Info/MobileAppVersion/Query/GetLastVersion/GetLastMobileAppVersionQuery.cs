using MediatR;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class GetLastMobileAppVersionQuery :
    IRequest<MobileAppVersionDto>
{ }
