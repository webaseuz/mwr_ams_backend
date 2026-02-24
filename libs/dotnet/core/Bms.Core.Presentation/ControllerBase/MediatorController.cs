using Bms.WEBASE.Controller;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Bms.Core.Presentation;

public class MediatorController : WebaseController
{
    private ISender _sender = null;

    protected ISender Mediator => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
