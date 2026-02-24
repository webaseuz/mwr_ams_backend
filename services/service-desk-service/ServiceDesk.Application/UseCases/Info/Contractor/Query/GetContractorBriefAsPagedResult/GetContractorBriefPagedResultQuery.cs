using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Info.Contractors;

public class GetContractorBriefPagedResultQuery :
      SortFilterPageOptions,
        IRequest<PagedResultWithActionControls<ContractorBriefDto>>
{
}
