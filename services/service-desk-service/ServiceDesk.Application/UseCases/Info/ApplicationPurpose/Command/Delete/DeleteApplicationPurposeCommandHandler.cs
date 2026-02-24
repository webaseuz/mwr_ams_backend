using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.UseCases.DeviceModels;

namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

public class DeleteApplicationPurposeCommandHandler :
    IRequestHandler<DeleteApplicationPurposeCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeleteApplicationPurposeCommandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(DeleteApplicationPurposeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ApplicationPurposes
            .IsSoftActive()
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
