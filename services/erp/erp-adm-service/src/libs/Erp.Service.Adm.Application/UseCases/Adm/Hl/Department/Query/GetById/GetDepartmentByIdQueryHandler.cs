using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

public class GetDepartmentByIdQueryHandler : IRequestHandler<DepartmentGetByIdQuery, DepartmentDto>
{
    private readonly IApplicationDbContext _context;
    private readonly ILocalizationBuilder _localizationBuilder;

    public GetDepartmentByIdQueryHandler(
        IApplicationDbContext context,
        ILocalizationBuilder localizationBuilder)
    {
        _context = context;
        _localizationBuilder = localizationBuilder;
    }

    public async Task<DepartmentDto> Handle(DepartmentGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Departments
            .Include(d => d.Branch)
            .Include(d => d.Translates)
            .Where(d => d.Id == request.Id && d.StateId == WbStateIdConst.ACTIVE)
            .Select(d => new DepartmentDto
            {
                Id = d.Id,
                BranchId = d.BranchId,
                OrganizationId = d.Branch.OrganizationId,
                ShortName = d.ShortName,
                FullName = d.FullName,
                Code = d.Code,
                OrderCode = d.OrderCode,
                StateId = d.StateId,
                Translates = d.Translates.Select(t => new DepartmentTranslateDto
                {
                    Id = t.Id,
                    OwnerId = t.OwnerId,
                    LanguageId = t.LanguageId,
                    ColumnName = t.ColumnName,
                    TranslateText = t.TranslateText
                }).ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = _localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        return entity;
    }
}
