using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class UserGetByIdQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<UserGetByIdQuery, UserBriefDto>
{
    public async Task<UserBriefDto> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await context.Users
            .Include(x => x.Person)
            .Include(x => x.UserRoles.Where(ur => !ur.IsDeleted)).ThenInclude(ur => ur.Role)
            .Include(x => x.State)
            .Where(x => !x.IsDeleted)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "USER_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("USER_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        return mapper.Map<UserBriefDto>(entity);
    }
}
