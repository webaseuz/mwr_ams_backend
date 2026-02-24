using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Organizations;

public class DeleteOrganizationCommand :
	IRequest<SuccessResult<bool>>
{
	public int Id { get; set; }
}
