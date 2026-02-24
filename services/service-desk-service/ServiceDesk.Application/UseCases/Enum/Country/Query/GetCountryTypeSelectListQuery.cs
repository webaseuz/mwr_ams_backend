using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Countries;

public class GetCountryTypeSelectListQuery : IRequest<SelectList<int>>
{
}

