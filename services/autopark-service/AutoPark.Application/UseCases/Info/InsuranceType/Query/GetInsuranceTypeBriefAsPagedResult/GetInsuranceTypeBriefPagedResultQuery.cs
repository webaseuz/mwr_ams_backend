using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class GetInsuranceTypeBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<InsuranceTypeBriefDto>>
{ }
