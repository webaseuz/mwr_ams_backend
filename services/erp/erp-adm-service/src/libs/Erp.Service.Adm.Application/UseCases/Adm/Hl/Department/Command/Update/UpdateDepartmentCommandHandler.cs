using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class UpdateDepartmentCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<DepartmentUpdateCommand, bool>
{
    public async Task<bool> Handle(DepartmentUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Departments
            .Include(d => d.Translates)
            .FirstOrDefaultAsync(d => d.Id == request.Id && d.StateId == WbStateIdConst.ACTIVE, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        entity.BranchId = request.BranchId;
        entity.ShortName = request.ShortName;
        entity.FullName = request.FullName;
        entity.Code = request.Code;
        entity.OrderCode = request.OrderCode;

        context.DepartmentTranslates.RemoveRange(entity.Translates);
        entity.Translates.Clear();

        foreach (var t in request.Translates)
            entity.Translates.Add(new DepartmentTranslate
            {
                LanguageId = t.LanguageId,
                ColumnName = t.ColumnName,
                TranslateText = t.TranslateText
            });

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
