using Erp.Core.Models;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using Erp.Service.Audit.MessageBroker.Publishers;
using Erp.Service.Audit.MessageBroker.QueueMessages;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WEBASE;

namespace Erp.Service.Adm.Application;

public class RowChangeLogCreateCommandHandler<TId, TEntity>
    : IRequestHandler<RowChangeLogCreateCommand<TId, TEntity>, bool>
    where TEntity : ISysEntity<TId>
    where TId : struct
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMediator _mediator;
    private readonly IMainAuthService _authService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IRowHistoryPublisher _rowHistoryPublisher;
    private readonly ILocalizationBuilder _localizationBuilder;

    public RowChangeLogCreateCommandHandler(
        IApplicationDbContext dbContext,
        IMediator mediator,
        IMainAuthService authService,
        IHttpContextAccessor httpContextAccessor,
        IRowHistoryPublisher rowHistoryPublisher,
        ILocalizationBuilder localizationBuilder)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _authService = authService;
        _httpContextAccessor = httpContextAccessor;
        _rowHistoryPublisher = rowHistoryPublisher;
        _localizationBuilder = localizationBuilder;
    }

    public async Task<bool> Handle(RowChangeLogCreateCommand<TId, TEntity> request, CancellationToken cancellationToken)
    {
        try
        {

            var entityDto = await _mediator.Send(request.GetByIdQuery, cancellationToken);

            if (entityDto is null)
                throw new WbNotFoundException()
                    .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                    .WithErrors(new WbFailure
                    {
                        Key = "DATA_NOT_FOUND",
                        ErrorMessage = _localizationBuilder.For("DATA_NOT_FOUND").ToString()
                    });

            var log = new RowChangeLog
            {
                TableId = entityDto.TableId,
                RowId = (long)Convert.ChangeType(entityDto.Id, typeof(long)),
                UserId = Convert.ToInt32(_authService.UserId),
                UserInfo = JsonConvert.SerializeObject(_authService.User.ToString()),
                IpAddress = _authService?.UserIp ?? "unknown",
                UserAgent = _authService?.UserAgent ?? "unknown",
                Message = request.Message,
                OrganizationId = _authService.CurrentOrganizationId,
                DateAt = DateTime.Now,
                RequestTraceId = _httpContextAccessor.HttpContext?.TraceIdentifier
                    ?? Guid.NewGuid().ToString()
            };

            _dbContext.RowChangeLogs.Add(log);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var rowHistoryMessage = new RowHistoryMessage
            {
                ChangeLogId = log.Id,
                StateId = 0,
                RowContent = JsonConvert.SerializeObject(entityDto),
                TableId = entityDto.TableId,
                RowId = (long)Convert.ChangeType(entityDto.Id, typeof(long)),
                UserId = Convert.ToInt32(_authService.UserId),
                UserInfo = JsonConvert.SerializeObject(_authService.User.ToString()),
                IpAddress = _authService?.UserIp ?? "unknown",
                UserAgent = _authService?.UserAgent ?? "unknown",
                Message = request.Message,
                OrganizationId = _authService.CurrentOrganizationId,
                DateAt = DateTime.Now,
                RequestTraceId = _httpContextAccessor.HttpContext?.TraceIdentifier
                   ?? Guid.NewGuid().ToString()
            };

            await _rowHistoryPublisher.TryPublishAsync(rowHistoryMessage);

            return log.Id > 0;
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex}");
        }
    }
}
