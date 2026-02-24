using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.FuelTypes;

public class GetFuelTypeBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<FuelTypeBriefDto>>
{ }
