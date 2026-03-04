using MediatR;

namespace Erp.Service.Adm.Models;
public class UserUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public int OrganizationId { get; set; }
    public string OrganizationName { get; set; }
    //public PersonCreateDto Person { get; set; }
    public int LanguageId { get; set; }
    public int StateId { get; set; }
    public List<UserRoleCreateDto> UserRoles { get; set; }
    public List<UserOrganizationCreateDto> UserOrganizations { get; set; }
    public List<UserTranslateCreateUpdateCommand> Translates { get; set; } = new List<UserTranslateCreateUpdateCommand>();
}
