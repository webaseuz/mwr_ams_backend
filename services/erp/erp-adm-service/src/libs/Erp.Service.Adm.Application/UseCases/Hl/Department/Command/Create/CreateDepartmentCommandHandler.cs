using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CreateDepartmentCommandHandler(
    IApplicationDbContext context) : IRequestHandler<DepartmentCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(DepartmentCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new Department
        {
            BranchId = request.BranchId,
            ShortName = request.ShortName,
            FullName = request.FullName,
            Code = request.Code,
            OrderCode = request.OrderCode,
            StateId = WbStateIdConst.ACTIVE
        };

        foreach (var t in request.Translates)
            entity.Translates.Add(new DepartmentTranslate
            {
                LanguageId = t.LanguageId,
                ColumnName = t.ColumnName,
                TranslateText = t.TranslateText
            });

        await context.Departments.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}
