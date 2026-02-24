using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TireModels;

public class GetTireModelSelectListQuery :
    IRequest<SelectList<int>>
{
}
