using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Organizations;

public class GetOrganizationTypeSelectListQuery : IRequest<SelectList<int>>
{
}
