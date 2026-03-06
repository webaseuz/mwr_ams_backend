using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class AcceptExpenseCommandHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<ExpenseAcceptCommand, bool>
{
    public async Task<bool> Handle(ExpenseAcceptCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Expenses
            .Include(x => x.Batteries.Where(b => !b.IsDeleted))
            .Include(x => x.Insurances.Where(b => !b.IsDeleted))
            .Include(x => x.Inspections.Where(b => !b.IsDeleted))
            .Include(x => x.Liquids.Where(b => !b.IsDeleted))
            .Include(x => x.Oils.Where(b => !b.IsDeleted))
            .Include(x => x.Tires.Where(b => !b.IsDeleted))
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        if (!StatusIdConst.CanExpenseStatus(entity.StatusId, StatusIdConst.ACCEPTED))
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "STATUS_NOT_ALLOWED_FOR_APPROVAL",
                    ErrorMessage = localizationBuilder.For("STATUS_NOT_ALLOWED_FOR_APPROVAL").ToString()
                });

        entity.StatusId = StatusIdConst.ACCEPTED;

        var batteriesWithoutInvoice = entity.Batteries
            .Where(x => !x.IsDeleted && string.IsNullOrWhiteSpace(x.InvoiceNumber))
            .Select(x => x.Id).ToArray();
        if (batteriesWithoutInvoice.Any())
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "INVOICE_NUMBER_MISSING",
                    ErrorMessage = localizationBuilder.For("INVOICE_NUMBER_MISSING")
                        .WithData(new { Collection = nameof(entity.Batteries), Ids = batteriesWithoutInvoice }).ToString()
                });

        var insurancesWithoutInvoice = entity.Insurances
            .Where(x => !x.IsDeleted && string.IsNullOrWhiteSpace(x.InvoiceNumber))
            .Select(x => x.Id).ToArray();
        if (insurancesWithoutInvoice.Any())
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "INVOICE_NUMBER_MISSING",
                    ErrorMessage = localizationBuilder.For("INVOICE_NUMBER_MISSING")
                        .WithData(new { Collection = nameof(entity.Insurances), Ids = insurancesWithoutInvoice }).ToString()
                });

        var inspectionsWithoutInvoice = entity.Inspections
            .Where(x => !x.IsDeleted && string.IsNullOrWhiteSpace(x.InvoiceNumber))
            .Select(x => x.Id).ToArray();
        if (inspectionsWithoutInvoice.Any())
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "INVOICE_NUMBER_MISSING",
                    ErrorMessage = localizationBuilder.For("INVOICE_NUMBER_MISSING")
                        .WithData(new { Collection = nameof(entity.Inspections), Ids = inspectionsWithoutInvoice }).ToString()
                });

        var liquidsWithoutInvoice = entity.Liquids
            .Where(x => !x.IsDeleted && string.IsNullOrWhiteSpace(x.InvoiceNumber))
            .Select(x => x.Id).ToArray();
        if (liquidsWithoutInvoice.Any())
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "INVOICE_NUMBER_MISSING",
                    ErrorMessage = localizationBuilder.For("INVOICE_NUMBER_MISSING")
                        .WithData(new { Collection = nameof(entity.Liquids), Ids = liquidsWithoutInvoice }).ToString()
                });

        var oilsWithoutInvoice = entity.Oils
            .Where(x => !x.IsDeleted && string.IsNullOrWhiteSpace(x.InvoiceNumber))
            .Select(x => x.Id).ToArray();
        if (oilsWithoutInvoice.Any())
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "INVOICE_NUMBER_MISSING",
                    ErrorMessage = localizationBuilder.For("INVOICE_NUMBER_MISSING")
                        .WithData(new { Collection = nameof(entity.Oils), Ids = oilsWithoutInvoice }).ToString()
                });

        var tiresWithoutInvoice = entity.Tires
            .Where(x => !x.IsDeleted && string.IsNullOrWhiteSpace(x.InvoiceNumber))
            .Select(x => x.Id).ToArray();
        if (tiresWithoutInvoice.Any())
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "INVOICE_NUMBER_MISSING",
                    ErrorMessage = localizationBuilder.For("INVOICE_NUMBER_MISSING")
                        .WithData(new { Collection = nameof(entity.Tires), Ids = tiresWithoutInvoice }).ToString()
                });

        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
