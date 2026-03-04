using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class CreateDriverCommandHandler(
    IApplicationDbContext context,
    IWbStorageService wbStorageService,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<DriverCreateCommand, WbHaveId<int>>
{
    public async Task<WbHaveId<int>> Handle(DriverCreateCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            if (request.Documents.GroupBy(a => a.DocumentTypeId).Any(a => a.Count() > 1))
                throw new WbClientException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure
                    {
                        Key = "DUPLICATE_DOCUMENT_TYPE",
                        ErrorMessage = localizationBuilder.For("DUPLICATE_DOCUMENT_TYPE").ToString()
                    });

            var personData = await context.People
                .FirstOrDefaultAsync(p => p.Pinfl == request.Person.Pinfl, cancellationToken);

            if (personData is not null && await context.Drivers.AnyAsync(x => x.PersonId == personData.Id && x.StateId == WbStateIdConst.ACTIVE, cancellationToken))
                throw new WbClientException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure
                    {
                        Key = "ALREADY_EXISTS",
                        ErrorMessage = localizationBuilder.For("ALREADY_EXISTS").ToString()
                    });

            long personId;

            if (personData is null)
            {
                var person = new Person
                {
                    Pinfl = request.Person.Pinfl,
                    Inn = request.Person.Inn,
                    DocumentTypeId = request.Person.DocumentTypeId,
                    DocumentSeria = request.Person.DocumentSeria,
                    DocumentNumber = request.Person.DocumentNumber,
                    LastName = request.Person.LastName,
                    FirstName = request.Person.FirstName,
                    MiddleName = request.Person.MiddleName,
                    FullName = $"{request.Person.LastName} {request.Person.FirstName} {request.Person.MiddleName}".Trim(),
                    BirthOn = request.Person.BirthOn,
                    GenderId = request.Person.GenderId,
                    BirthCountryId = request.Person.BirthCountryId,
                    BirthRegionId = request.Person.BirthRegionId,
                    BirthDistrictId = request.Person.BirthDistrictId,
                    CitizenshipId = request.Person.CitizenshipId,
                    LivingRegionId = request.Person.LivingRegionId,
                    LivingDistrictId = request.Person.LivingDistrictId,
                    FileId = request.Person.FileId,
                    FileName = request.Person.FileName,
                    StateId = WbStateIdConst.ACTIVE
                };

                await context.People.AddAsync(person, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);

                personId = person.Id;

                if (request.Person.FileId.HasValue)
                    await wbStorageService.MoveToPersistentAsync(
                        FileStorageConst.PERSON_FILE,
                        person.Id.ToString(),
                        new[] { request.Person.FileId.Value });
            }
            else
            {
                personId = personData.Id;
            }

            var entity = new Driver
            {
                BranchId = request.BranchId,
                PersonId = personId,
                UniqueCode = Guid.NewGuid(),
                StateId = WbStateIdConst.ACTIVE
            };

            foreach (var doc in request.Documents)
                entity.Documents.Add(new DriverDocument
                {
                    DocumentTypeId = doc.DocumentTypeId,
                    DocumentNumber = doc.DocumentNumber,
                    DocumentFileId = doc.DocumentFileId,
                    DocumentFileName = doc.DocumentFileName,
                    DocumentEndOn = doc.DocumentEndOn
                });

            await context.Drivers.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            var fileIds = request.Documents
                .Where(x => x.DocumentFileId.HasValue)
                .Select(x => x.DocumentFileId!.Value)
                .ToArray();

            if (fileIds.Length > 0)
                await wbStorageService.MoveToPersistentAsync(
                    FileStorageConst.DRIVER_DOCUMENT_FILE,
                    entity.Id.ToString(),
                    fileIds);

            await transaction.CommitAsync(cancellationToken);

            return new WbHaveId<int>(entity.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}
