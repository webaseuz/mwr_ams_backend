using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Banks;

public class GetBankBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<BankBriefDto>>
{ }
