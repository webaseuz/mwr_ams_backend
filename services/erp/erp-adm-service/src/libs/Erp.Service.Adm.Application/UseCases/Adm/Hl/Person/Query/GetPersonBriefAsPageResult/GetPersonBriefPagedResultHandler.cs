using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

public class GetPersonBriefPagedResultHandler : IRequestHandler<PersonGetListQuery, WbPagedResult<PersonBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICultureHelper _cultureHelper;

    public GetPersonBriefPagedResultHandler(
        IApplicationDbContext context,
        IMapper mapper,
        ICultureHelper cultureHelper)
    {
        _context = context;
        _mapper = mapper;
        _cultureHelper = cultureHelper;
    }

    public async Task<WbPagedResult<PersonBriefDto>> Handle(PersonGetListQuery request, CancellationToken cancellationToken)
    {
        var query = _context.People
            .Where(x => !x.IsDeleted)
            .MapTo<PersonBriefDto>(_mapper, _cultureHelper);

        if (request.HasSearch())
        {
            var search = request.Search.ToLower();
            query = query.Where(x =>
                x.FullName.ToLower().Contains(search) ||
                x.Pinfl.Contains(search) ||
                x.FirstName.ToLower().Contains(search) ||
                x.LastName.ToLower().Contains(search));
        }

        return await query.AsPagedResultAsync(request);
    }
}
