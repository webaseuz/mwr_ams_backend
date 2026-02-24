using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Countries;

public class GetCountryTypeSelectListQuery : IRequest<SelectList<int>>
{
}

