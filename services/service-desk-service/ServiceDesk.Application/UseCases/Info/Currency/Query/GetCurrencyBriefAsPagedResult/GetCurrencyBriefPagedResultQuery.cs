using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Currencies;

public class GetCurrencyBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<CurrencyBriefDto>>
{ }
