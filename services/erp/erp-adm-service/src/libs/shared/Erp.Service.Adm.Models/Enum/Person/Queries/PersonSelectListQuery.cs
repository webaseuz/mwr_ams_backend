using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class PersonSelectListQuery : IRequest<WbSelectList<long>>
{
    public int? BranchId { get; set; }
}