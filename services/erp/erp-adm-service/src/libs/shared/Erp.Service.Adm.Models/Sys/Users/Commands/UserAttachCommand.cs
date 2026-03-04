using MediatR;
using Erp.Core.Models;
using Erp.Core.Sdk.Models;

namespace Erp.Service.Adm.Models;
public class UserAttachCommand : IRequest<bool>
{
    public string OrderCode { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public int OrganizationId { get; set; }
    public string OrganizationName { get; set; }
    public PersonCreateCommand Person { get; set; }
    public List<UserRoleCreateDto> UserRoles { get; set; }
    public List<UserOrganizationCreateDto> UserOrganizations { get; set; }
}
