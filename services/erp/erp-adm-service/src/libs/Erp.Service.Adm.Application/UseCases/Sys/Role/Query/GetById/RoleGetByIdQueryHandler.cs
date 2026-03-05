using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class RoleGetByIdQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<RoleGetByIdQuery, RoleDto>
{
    public async Task<RoleDto> Handle(RoleGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await context.Roles
            .Include(x => x.RolePermissions.Where(p => !p.IsDeleted))
            .Include(x => x.Translates)
            .Include(x => x.State).ThenInclude(s => s.Translates)
            .Where(x => !x.IsDeleted)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "ROLE_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("ROLE_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        return mapper.Map<RoleDto>(entity);
    }
}
