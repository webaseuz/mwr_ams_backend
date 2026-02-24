using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Info.Contractors;

public class GetContractorBriefPagedResultQuery :
      SortFilterPageOptions,
        IRequest<PagedResultWithActionControls<ContractorBriefDto>>
{
}
