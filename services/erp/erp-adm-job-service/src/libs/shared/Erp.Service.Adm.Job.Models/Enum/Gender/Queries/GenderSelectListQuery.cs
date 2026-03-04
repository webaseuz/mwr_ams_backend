using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class GenderSelectListQuery : IRequest<WbSelectList<int>>
{
}
