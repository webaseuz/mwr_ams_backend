using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class RegionSelectListQuery : IRequest<WbSelectList<int, RegionSelectListDto>>
{

}
