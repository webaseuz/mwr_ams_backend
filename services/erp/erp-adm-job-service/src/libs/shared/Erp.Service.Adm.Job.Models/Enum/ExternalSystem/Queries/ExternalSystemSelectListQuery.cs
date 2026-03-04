using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class ExternalSystemSelectListQuery : IRequest<WbSelectList<int>>
{
}
