using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

public class GetDriverDocumentByIdQueryHandler : IRequestHandler<DriverDocumentGetByIdQuery, DriverDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICultureHelper _cultureHelper;

    public GetDriverDocumentByIdQueryHandler(
        IApplicationDbContext context,
        IMapper mapper,
        ICultureHelper cultureHelper)
    {
        _context = context;
        _mapper = mapper;
        _cultureHelper = cultureHelper;
    }

    public async Task<DriverDto> Handle(DriverDocumentGetByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Drivers
            .Where(x => x.Id == request.Id && x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<DriverDto>(_mapper, _cultureHelper)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
