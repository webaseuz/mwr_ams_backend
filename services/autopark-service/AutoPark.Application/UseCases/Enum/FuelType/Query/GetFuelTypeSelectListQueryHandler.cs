using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.FuelTypes;

public class GetFuelTypeSelectListQueryHandler :
    IRequestHandler<GetFuelTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetFuelTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }



    public async Task<SelectList<int>> Handle(GetFuelTypeSelectListQuery request,
                                        CancellationToken cancellationToken)
    {
        if (request.TransportSettingId.HasValue)
        {
            var result = await _context.TransportSettings
                .Where(a => a.Id == request.TransportSettingId)
                .SelectMany(a => a.Fuels.Select(f => f.FuelType))
                .Distinct()
                .AsSelectList(cancellationToken);

            return result;
        }

        return await _context.FuelTypes
                .AsSelectList(cancellationToken);
    }
}
