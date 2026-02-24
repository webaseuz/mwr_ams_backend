using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Organizations;

public class DeleteOrganizationCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
