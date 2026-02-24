using AutoPark.Application.UseCases.Persons;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Drivers;

public class UpdateDriverCommandHandler :
    IRequestHandler<UpdateDriverCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;

    public UpdateDriverCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        IStorageAsyncService storageAsyncService)
    {
        _context = context;
        _mapper = mapper;
        _storageAsyncService = storageAsyncService;
    }

    public async Task<IHaveId<int>> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
    {
        if (request.Person.Inn.IsNullOrEmptyObject())
            request.Person.Inn = null;

        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var hasActiveDriver = _context.Drivers
                .Any(x => x.PersonId == request.Person.Id &&
                          x.StateId == StateIdConst.ACTIVE && x.Id != request.Id);

            if (hasActiveDriver)
                throw ClientLogicalExceptionHelper.AlreadyExists(nameof(request.Person));

            var entity = await _context.Drivers
                .Include(x => x.Documents)
                .IsSoftActive()
                .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (entity == null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            #region File logic
            if (request.Documents.Any(x => x.DocumentFileId.HasValue) || entity.Documents.Any(x => x.DocumentFileId.HasValue))
            {
                // deletedFiles
                var deletedFiles = entity.Documents.Where(x => x.DocumentFileId.HasValue && !request.Documents.Select(x => x.DocumentFileId).Contains(x.DocumentFileId.Value))
                                                    .Select(x => x.DocumentFileId.Value).ToArray();

                _storageAsyncService.MarkFileForDelete(FileStorageConst.DRIVER_DOCUMENT_FILE, entity.Id.ToString(), deletedFiles);

                // addedFiles
                var addedFiles = request.Documents.Where(x => x.DocumentFileId.HasValue &&
                                !entity.Documents.Select(x => x.DocumentFileId).Contains(x.DocumentFileId.Value))
                                                    .Select(x => x.DocumentFileId.Value).ToArray();

                _storageAsyncService.MarkFileForMoveToPersistent(FileStorageConst.DRIVER_DOCUMENT_FILE,
                                                                 entity.Id.ToString(),
                                                                 addedFiles);

                await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.DRIVER_DOCUMENT_FILE,
                                                                   documentId: entity.Id.ToString());
            }
            #endregion

            if (!request.Documents.Any(x => x.DocumentTypeId == DocumentTypeIdConst.DRIVER_LICENCE))
            {
                throw new Exception("Haydovchilik guvohnomasi majburiy!");
            }

            if (request.Documents.GroupBy(a => a.DocumentTypeId).Any(a => a.Count() > 1))
            {
                throw new Exception("Har bir hujjat turi uchun maksimal 1 ta fayl qo'shish mumkin!");
            }

            request.Person.BranchId = entity.BranchId;


            var person = await _context.People
                .FirstOrDefaultAsync(p => p.Id == entity.PersonId, cancellationToken);

            if (request.Person.Id == entity.Person.Id)
            {
                //person.Inn = request.Person.Inn;
                //person.Pinfl = request.Person.Pinfl;    
                //person.DocumentNumber = request.Person.DocumentNumber;
                //person.DocumentTypeId = request.Person.DocumentTypeId;
                //person.DocumentSeria = request.Person.DocumentSeria;
                //person.FirstName = request.Person.FirstName;
                //person.LastName = request.Person.LastName;
                //person.MiddleName = request.Person.MiddleName;
                //person.SetFIO();
                //person.FileName = request.Person.FileName;
                //person.FileId = request.Person.FileId;
                //person.BirthCountryId = request.Person.BirthCountryId;
                //person.BirthRegionId = request.Person.BirthRegionId;
                //person.BirthDistrictId = request.Person.BirthDistrictId;
                //person.GenderId = request.Person.GenderId;
                //person.BirthOn = request.Person.BirthOn;
                //person.CitizenshipId = request.Person.CitizenshipId;
                //person.LivingDistrictId = request.Person.LivingDistrictId;
                //person.LivingRegionId = request.Person.LivingRegionId;
                //person.BranchId = request.Person.BranchId;
                request.Person.UpdateEntity(person, _mapper);
            }

            else
                entity.PersonId = request.Person.Id;

            PersonFile(request.Person, person);
            //Person Update

            person.SetFIO();
            request.UpdateEntity(entity, _mapper);

            var res = await _context.SaveChangesAsync(cancellationToken);

            await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.PERSON_FILE,
                                                               documentId: entity.PersonId.ToString());

            transaction.Commit();
            return HaveId.Create(request.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
    private void PersonFile(UpdatePersonCommand request, Person entity)
    {

        if (request.FileId.HasValue && entity.FileId != request.FileId)
        {
            if (entity.FileId.HasValue)
                _storageAsyncService.MarkFileForDelete(FileStorageConst.PERSON_FILE,
                                                       entity.Id.ToString(),
                                                       entity.FileId.Value);

            _storageAsyncService.MarkFileForMoveToPersistent(FileStorageConst.PERSON_FILE,
                                                             entity.Id.ToString(),
                                                             request.FileId.Value);
        }
    }
}

