using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application;
public class RowChangeLogGetListQueryHandler : IRequestHandler<RowChangeLogGetListQuery, List<RowChangeLogBriefDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ICultureHelper _cultureHelper;

    public RowChangeLogGetListQueryHandler(IApplicationDbContext dbContext, IMapper mapper, ICultureHelper cultureHelper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _cultureHelper = cultureHelper;
    }

    public async Task<List<RowChangeLogBriefDto>> Handle(RowChangeLogGetListQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.RowChangeLogs
            .AsNoTracking()
            .Where(x => x.TableId == request.TableId && x.RowId == request.RowId)
            .MapTo<RowChangeLogBriefDto>(_mapper, _cultureHelper)
            .ToListAsync(cancellationToken);

        return query;
    }
}
