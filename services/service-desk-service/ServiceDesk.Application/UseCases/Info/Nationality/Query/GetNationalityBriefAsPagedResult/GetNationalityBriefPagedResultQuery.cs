using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Nationalities;

public class GetNationalityBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<NationalityBriefDto>>
{ }
