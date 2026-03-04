using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class ExternalStatusSelectListQuery : IRequest<WbSelectList<int>>
{
}
