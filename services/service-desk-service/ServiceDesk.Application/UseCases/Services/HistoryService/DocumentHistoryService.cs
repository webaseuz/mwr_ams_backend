using Bms.Core.Domain.Domains;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ServiceDesk.Application.Security;
using ServiceDesk.Domain.Constants;
using System.Text;

namespace ServiceDesk.Application.UseCases.Services.HistoryService;

public class DocumentHistoryService : IDocumentHistoryService
{
	private readonly IAsyncAppAuthService _appAuthService;
	private readonly IWriteEfCoreContext _context;
	private readonly IStorageAsyncService _storageAsyncService;
	public DocumentHistoryService(IAsyncAppAuthService appAuthService,
								  IWriteEfCoreContext context,
								  IStorageAsyncService storageAsyncService/*AuthService*/)
	{
		_storageAsyncService = storageAsyncService;
		_appAuthService = appAuthService;
		_context = context;
	}
	public async Task<Guid> AddHistory<TId, TEntity, TData>(TData data,
										 CancellationToken cancellationToken)
	   where TEntity : class,
			 IHaveIdProp<TId>,
			 IDocumentEntity
	   where TData : class,
			 IHaveIdProp<TId>
	{
		var transaction = _context.Database.CurrentTransaction ?? _context.Database.BeginTransaction();

		bool canCommit = _context.Database.CurrentTransaction == null;

		try
		{
			var userInfo = await _appAuthService.GetUserIdentityAsync();
			string dataJson = JsonConvert.SerializeObject(data);

			//minio logic
			var documentName = FileStorageConstHelper<TEntity>.GetDocumenHistory();

			byte[] byteArray = Encoding.UTF8.GetBytes(dataJson);

			using var memoryStream = new MemoryStream(byteArray);

			IStorageFileInfo storageFileInfo = new StorageFileInfo(Guid.NewGuid(), documentName);

			StorageFile dtoFiles = new StorageFile(storageFileInfo.FileName, memoryStream);

			var file = await _storageAsyncService.SaveTempAsync(documentName, dtoFiles);

			var entity = await _context.Set<TEntity>()
				.FirstOrDefaultAsync(e => e.Id.Equals(data.Id));

			entity.AddHistory(file.FirstOrDefault().FileId, userInfo);

			if (canCommit)
				await transaction.CommitAsync(cancellationToken);

			return file.FirstOrDefault().FileId;
		}
		catch (Exception)
		{
			if (canCommit)
				await transaction.RollbackAsync(cancellationToken);

			throw;
		}
	}
}
