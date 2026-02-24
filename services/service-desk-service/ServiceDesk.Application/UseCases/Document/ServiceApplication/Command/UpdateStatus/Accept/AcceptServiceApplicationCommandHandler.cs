using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class AcceptServiceApplicationCommandHandler :
    IRequestHandler<AcceptServiceApplicationCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;

    public AcceptServiceApplicationCommandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<IHaveId<long>> Handle(
        AcceptServiceApplicationCommand request, 
        CancellationToken cancellationToken)
    {
        var document = await _context.ServiceApplications
             .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (document is null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        document.Accept();

        await _context.SaveChangesAsync(cancellationToken);

        return HaveId.Create(request.Id);
    }
}
