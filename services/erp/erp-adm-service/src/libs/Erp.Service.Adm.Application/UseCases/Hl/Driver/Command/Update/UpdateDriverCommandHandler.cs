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

internal sealed class UpdateDriverCommandHandler(
    IApplicationDbContext context,
    IWbStorageService wbStorageService,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<DriverUpdateCommand, bool>
{
    public async Task<bool> Handle(DriverUpdateCommand request, CancellationToken cancellationToken)
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

            var entity = await context.Drivers
                .Include(x => x.Documents.Where(d => !d.IsDeleted))
                .FirstOrDefaultAsync(b => b.Id == request.Id && b.StateId == WbStateIdConst.ACTIVE, cancellationToken);

            if (entity is null)
                throw new WbClientException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure
                    {
                        Key = "DOCUMENT_NOT_FOUND",
                        ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                    });

            // Determine new file IDs to move to persistent
            var existingFileIds = entity.Documents
                .Where(d => d.DocumentFileId.HasValue)
                .Select(d => d.DocumentFileId!.Value)
                .ToHashSet();

            var newFileIds = request.Documents
                .Where(d => d.DocumentFileId.HasValue && !existingFileIds.Contains(d.DocumentFileId!.Value))
                .Select(d => d.DocumentFileId!.Value)
                .ToArray();

            // Soft-delete all existing documents
            foreach (var doc in entity.Documents)
                doc.IsDeleted = true;

            // Add all documents from request
            foreach (var doc in request.Documents)
                entity.Documents.Add(new DriverDocument
                {
                    DocumentTypeId = doc.DocumentTypeId,
                    DocumentNumber = doc.DocumentNumber,
                    DocumentEndOn = doc.DocumentEndOn,
                    DocumentFileId = doc.DocumentFileId,
                    DocumentFileName = doc.DocumentFileName
                });

            // Update driver base fields
            entity.BranchId = request.BranchId;

            // Update person
            if (request.Person.Id == entity.PersonId)
            {
                var person = await context.People
                    .FirstOrDefaultAsync(p => p.Id == entity.PersonId, cancellationToken);

                if (person is not null)
                {
                    person.Pinfl = request.Person.Pinfl;
                    person.Inn = request.Person.Inn;
                    person.DocumentTypeId = request.Person.DocumentTypeId;
                    person.DocumentSeria = request.Person.DocumentSeria;
                    person.DocumentNumber = request.Person.DocumentNumber;
                    person.LastName = request.Person.LastName;
                    person.FirstName = request.Person.FirstName;
                    person.MiddleName = request.Person.MiddleName;
                    person.FullName = $"{request.Person.LastName} {request.Person.FirstName} {request.Person.MiddleName}".Trim();
                    person.BirthOn = request.Person.BirthOn;
                    person.GenderId = request.Person.GenderId;
                    person.BirthCountryId = request.Person.BirthCountryId;
                    person.BirthRegionId = request.Person.BirthRegionId;
                    person.BirthDistrictId = request.Person.BirthDistrictId;
                    person.CitizenshipId = request.Person.CitizenshipId;
                    person.LivingRegionId = request.Person.LivingRegionId;
                    person.LivingDistrictId = request.Person.LivingDistrictId;

                    if (request.Person.FileId.HasValue && person.FileId != request.Person.FileId)
                    {
                        person.FileId = request.Person.FileId;
                        person.FileName = request.Person.FileName;
                    }
                }
            }
            else
            {
                entity.PersonId = request.Person.Id;
            }

            await context.SaveChangesAsync(cancellationToken);

            // Move new document files to persistent
            if (newFileIds.Length > 0)
                await wbStorageService.MoveToPersistentAsync(
                    FileStorageConst.DRIVER_DOCUMENT_FILE,
                    entity.Id.ToString(),
                    newFileIds);

            // Move new person file to persistent
            if (request.Person.Id == entity.PersonId && request.Person.FileId.HasValue)
                await wbStorageService.MoveToPersistentAsync(
                    FileStorageConst.PERSON_FILE,
                    entity.PersonId.ToString(),
                    new[] { request.Person.FileId.Value });

            await transaction.CommitAsync(cancellationToken);

            return true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}
