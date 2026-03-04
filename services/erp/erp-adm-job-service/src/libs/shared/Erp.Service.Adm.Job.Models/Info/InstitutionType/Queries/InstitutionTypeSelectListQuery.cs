using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class InstitutionTypeSelectListQuery : IRequest<WbSelectList<int>>
{
    public int? OrganizationTypeId { get; set; }
}

