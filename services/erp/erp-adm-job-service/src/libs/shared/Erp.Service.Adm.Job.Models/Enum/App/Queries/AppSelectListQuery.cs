using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class AppSelectListQuery : IRequest<WbSelectList<int>>
{
}
