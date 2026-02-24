using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ServiceDesk.Application.UseCases.DeviceModels;

namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

public class GetApplicationPurposeQueryHandler :
    IRequestHandler<GetApplicationPurposeQuery, ApplicationPurposeDto>
{
    public Task<ApplicationPurposeDto> Handle(
        GetApplicationPurposeQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new ApplicationPurposeDto());
}

