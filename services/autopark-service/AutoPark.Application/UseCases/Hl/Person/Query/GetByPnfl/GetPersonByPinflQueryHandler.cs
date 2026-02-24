using AutoPark.Domain;
using AutoPark.Domain.Constants;
using AutoPark.Integration.Service;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Persons;

public class GetPersonByPinflQueryHandler :
    IRequestHandler<GetPersonByPinflQuery, PersonDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IWriteEfCoreContext _contextToWrite;
    private readonly ICashManagementService _cashManagementService;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;

    public GetPersonByPinflQueryHandler(IReadEfCoreContext context,
        IMapProvider mapper,
        ICashManagementService cashManagementService,
        IWriteEfCoreContext contextToWrite,
        IStorageAsyncService storageAsyncService)
    {
        _context = context;
        _mapper = mapper;
        _cashManagementService = cashManagementService;
        _contextToWrite = contextToWrite;
        _storageAsyncService = storageAsyncService;
    }

    public async Task<PersonDto> Handle(
        GetPersonByPinflQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.People
            .Where(b => b.Pinfl == request.Pinfl);

        var dto = await _mapper.MapCollection<Person, PersonDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
        {
            var userResult = await _cashManagementService
                .GetUserByPinfl(request.Pinfl, cancellationToken);

            if (userResult.IsSuccess && userResult.Response?.Data != null)
            {
                var user = userResult.Response.Data.FirstOrDefault();

                if (user == null)
                    throw ClientLogicalExceptionHelper.NotFoundPinfl(request.Pinfl);



                var personDto = new PersonDto
                {
                    Id = 0,
                    Pinfl = user.Pinfl ?? string.Empty,
                    Inn = user.Inn.IsNullOrEmptyObject() ? null : user.Inn,
                    FirstName = user.FirstName ?? string.Empty,
                    LastName = user.LastName ?? string.Empty,
                    MiddleName = user.MiddleName ?? string.Empty,
                    FullName = $"{user.LastName} {user.FirstName} {user.MiddleName}".Trim(),
                    DocumentSeria = user.PassportSeria ?? string.Empty,
                    DocumentNumber = user.PassportNumber ?? string.Empty,
                    GenderName = user.Gender ?? string.Empty,
                    BirthOn = user.BirthDate,
                    LivingDistrictName = user.Address ?? string.Empty,
                    BirthDistrictName = user.BirthPlace ?? string.Empty,
                    DocumentTypeId = DocumentTypeIdConst.PASSPORT,
                    DocumentTypeName = string.Empty,
                    GenderId = null,
                    BirthCountryId = null,
                    BirthCountryName = string.Empty,
                    BirthRegionId = null,
                    BirthRegionName = string.Empty,
                    BirthDistrictId = null,
                    CitizenshipId = null,
                    CitizenshipName = string.Empty,
                    LivingRegionId = null,
                    LivingRegionName = string.Empty,
                    BranchId = null,
                    BranchName = string.Empty,
                    FileId = null,
                    FileName = string.Empty
                };

                if (user.Gender.Contains("M"))
                    personDto.GenderId = 1;
                else
                    personDto.GenderId = 2;


                var createPersonCommand = new CreatePersonCommand
                {
                    BirthCountryId = personDto.BirthCountryId,
                    BirthDistrictId = personDto.BirthDistrictId,
                    Pinfl = personDto.Pinfl,
                    Inn = personDto.Inn,
                    FirstName = personDto.FirstName,
                    LastName = personDto.LastName,
                    MiddleName = personDto.MiddleName,
                    DocumentSeria = personDto.DocumentSeria,
                    DocumentNumber = personDto.DocumentNumber,
                    DocumentTypeId = personDto.DocumentTypeId,
                    BirthOn = personDto.BirthOn,
                    GenderId = personDto.GenderId,
                    FileId = personDto.FileId,
                    FileName = personDto.FileName,
                    LivingRegionId = personDto.LivingRegionId,
                    LivingDistrictId = personDto.LivingDistrictId,
                    CitizenshipId = personDto.CitizenshipId,
                    BirthRegionId = personDto.BirthRegionId,

                };
                var person = await CreatePersonAsync(createPersonCommand, cancellationToken);
                await _contextToWrite.SaveChangesAsync(cancellationToken);

                personDto.Id = person.Id;
                return personDto;
            }
            else
                throw ClientLogicalExceptionHelper.NotFoundPinfl(request.Pinfl);
        }

        return dto;
    }

    private async Task<Person> CreatePersonAsync(CreatePersonCommand personCommand,
                                                 CancellationToken cancellationToken)
    {
        var person = personCommand.CreateEntity<CreatePersonCommand, Person>(_mapper);

        person.SetFIO();
        person.MarkAsActive();

        await _contextToWrite.People.AddAsync(person, cancellationToken);
        await _contextToWrite.SaveChangesAsync(cancellationToken);

        if (personCommand.FileId.HasValue)
            await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.PERSON_FILE,
                                                             documentId: person.Id.ToString(),
                                                             tempFileIds: personCommand.FileId.Value);

        return person;
    }
}
