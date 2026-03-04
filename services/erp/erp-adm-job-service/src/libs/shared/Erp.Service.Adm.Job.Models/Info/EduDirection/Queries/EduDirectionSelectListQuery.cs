using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class EduDirectionSelectListQuery : IRequest<WbSelectList<int, EduDirectionSelectListDto>>
{
    public int? StateId { get; set; }
}
