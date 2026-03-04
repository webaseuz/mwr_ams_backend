using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class SpecialtySelectListQuery : IRequest<WbSelectList<int, SpecialtySelectListDto>>
{
    public int StateId { get; set; }
}
