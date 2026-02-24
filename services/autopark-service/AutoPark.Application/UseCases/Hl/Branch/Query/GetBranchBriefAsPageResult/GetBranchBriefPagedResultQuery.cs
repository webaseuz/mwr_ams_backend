using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Branches;

public class GetBranchBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<BranchBriefDto>>
{ }