using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

public class GetTransportByIdQueryHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<TransportGetByIdQuery, TransportDto>
{
    public async Task<TransportDto> Handle(TransportGetByIdQuery request, CancellationToken cancellationToken)
    {
        var dto = await context.Transports
            .Include(x => x.Files.Where(f => !f.IsDeleted))
            .Where(x => x.Id == request.Id && x.StateId == WbStateIdConst.ACTIVE)
            .Select(x => new TransportDto
            {
                Id = x.Id,
                OrderCode = x.OrderCode,
                BranchId = x.BranchId,
                BranchName = x.Branch.FullName,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department != null ? x.Department.FullName : null,
                UniqueCode = x.UniqueCode,
                TransportModelId = x.TransportModelId,
                TransportModelName = x.TransportModel.FullName,
                TransportUseTypeId = x.TransportUseTypeId,
                TransportUseTypeName = x.TransportUseType.FullName,
                TransportBrandId = x.TransportBrandId,
                TransportBrandName = x.TransportBrand.FullName,
                TransportColorId = x.TransportColorId,
                TransportColorName = x.TransportColor.FullName,
                ManufacturedAt = x.ManufacturedAt,
                PurchasedAt = x.PurchasedAt,
                StateCode = x.StateCode,
                StateNumber = x.StateNumber,
                VinNumber = x.VinNumber,
                PurchasedAmount = x.PurchasedAmount,
                AmortizationPeriod = x.AmortizationPeriod,
                QrCodeRegistryId = x.QrCodeRegistryId,
                StateName = x.State.FullName,
                Files = x.Files.Where(f => !f.IsDeleted).Select(f => new TransportFileDto
                {
                    Id = f.Id,
                    OwnerId = f.OwnerId,
                    FileName = f.FileName
                }).ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (dto is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        return dto;
    }
}
