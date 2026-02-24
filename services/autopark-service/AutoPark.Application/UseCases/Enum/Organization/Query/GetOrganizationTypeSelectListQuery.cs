using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Organizations;

public class GetOrganizationTypeSelectListQuery : IRequest<SelectList<int>>
{
}
