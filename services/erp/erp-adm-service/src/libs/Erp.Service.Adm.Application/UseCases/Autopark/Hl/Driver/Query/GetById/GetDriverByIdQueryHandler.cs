using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

public class GetDriverByIdQueryHandler : IRequestHandler<DriverGetByIdQuery, DriverDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICultureHelper _cultureHelper;
    private readonly ILocalizationBuilder _localizationBuilder;

    public GetDriverByIdQueryHandler(
        IApplicationDbContext context,
        IMapper mapper,
        ICultureHelper cultureHelper,
        ILocalizationBuilder localizationBuilder)
    {
        _context = context;
        _mapper = mapper;
        _cultureHelper = cultureHelper;
        _localizationBuilder = localizationBuilder;
    }

    public async Task<DriverDto> Handle(DriverGetByIdQuery request, CancellationToken cancellationToken)
    {
        var dto = await _context.Drivers
            .Where(x => x.Id == request.Id && x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<DriverDto>(_mapper, _cultureHelper)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = _localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        return dto;
    }
}
