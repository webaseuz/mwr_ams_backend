using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;
using WEBASE.Storage.Abstraction;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class PersonUploadPhotoCommandHandler(
    IApplicationDbContext context,
    IWbStorageService wbStorageService,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<PersonUploadPhotoCommand, Guid?>
{
    public async Task<Guid?> Handle(PersonUploadPhotoCommand request, CancellationToken cancellationToken)
    {
        if (request.File is null)
            return null;

        var entity = await context.People
            .FirstOrDefaultAsync(x => x.Id == request.PersonId, cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.PersonId }).ToString()
                });

        await wbStorageService.MoveToPersistentAsync(
            FileStorageConst.PERSON_FILE,
            entity.Id.ToString(),
            request.File.Id);

        entity.FileId = request.File.Id;
        entity.FileName = request.File.FileName;

        await context.SaveChangesAsync(cancellationToken);

        return request.File.Id;
    }
}
