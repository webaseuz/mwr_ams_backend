using MediatR;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class GetMobileAppVersionQuery :
    IRequest<MobileAppVersionDto>
{ }
