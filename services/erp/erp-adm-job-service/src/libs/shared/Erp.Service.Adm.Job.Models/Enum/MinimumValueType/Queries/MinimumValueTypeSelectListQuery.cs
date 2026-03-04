using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class MinimumValueTypeSelectListQuery : IRequest<WbSelectList<int, MinimumValueTypeSelectListDto>>
{
}
