using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class RolePositionCreateUpdateCommand : IRequest<WbHaveId<int>>
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public int OrganizationTypeId { get; set; }
    public int InstitutionTypeId { get; set; }
    public int PositionId { get; set; }
    public int DepartmentId { get; set; }
    public int StateId { get; set; }
}
