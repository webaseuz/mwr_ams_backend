using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class GetCitizenshipBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<CitizenshipBriefDto>>
{ }
