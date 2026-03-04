using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class KinshipDegreeSelectListQuery : IRequest<WbSelectList<int, KinshipDegreeSelectListDto>>
{
    public int StateId { get; set; }
}

