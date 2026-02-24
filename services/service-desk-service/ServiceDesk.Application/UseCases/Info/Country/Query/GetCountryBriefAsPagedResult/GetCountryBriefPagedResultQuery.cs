using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Countries;

public class GetCountryBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<CountryBriefDto>>
{ }
