using MediatR;
using WEBASE.AspNet;

namespace Erp.Service.Adm.WebApi;

public abstract class BaseController : WbController
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    protected BaseController() : base(new WbControllerConfig { EnableSecurityInfo = true })
    {

    }
}
