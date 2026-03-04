using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class OrganizationCreateCommandHandler(
    IApplicationDbContext context) : IRequestHandler<OrganizationCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(OrganizationCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new Organization
        {
            OrderCode = request.OrderCode,
            ShortName = request.ShortName,
            FullName = request.FullName,
            Inn = request.Inn,
            ParentId = request.ParentId,
            CountryId = request.CountryId,
            RegionId = request.RegionId,
            DistrictId = request.DistrictId,
            Address = request.Address,
            PhoneNumber = request.PhoneNumber,
            OkedId = request.OkedId,
            Director = request.Director,
            VatCode = request.VatCode,
            ZipCode = request.ZipCode,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            StateId = WbStateIdConst.ACTIVE
        };

        foreach (var t in request.Translates)
            entity.Translates.Add(new OrganizationTranslate
            {
                LanguageId = t.LanguageId,
                ColumnName = t.ColumnName.ToString(),
                TranslateText = t.TranslateText
            });

        await context.Organizations.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new WbHaveId<int>(entity.Id);
    }
}
