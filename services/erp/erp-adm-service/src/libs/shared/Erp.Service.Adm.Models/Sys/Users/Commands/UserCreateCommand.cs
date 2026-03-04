using MediatR;
using WEBASE;
using Erp.Core.Models;
using Erp.Core.Sdk.Models;

namespace Erp.Service.Adm.Models;
public class UserCreateCommand : IRequest<WbHaveId<int>>
{
    public string OrderCode { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public PersonCreateCommand Person { get; set; }
    public int LanguageId { get; set; }
    public int StateId { get; set; }
    public List<UserRoleCreateDto> UserRoles { get; set; }
    public List<UserOrganizationCreateDto> UserOrganizations { get; set; }
    public List<UserTranslateCreateUpdateCommand> Translates { get; set; } = new List<UserTranslateCreateUpdateCommand>();
}
