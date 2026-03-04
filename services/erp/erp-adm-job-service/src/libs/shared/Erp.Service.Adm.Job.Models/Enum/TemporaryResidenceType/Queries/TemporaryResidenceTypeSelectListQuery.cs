using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class TemporaryResidenceTypeSelectListQuery : IRequest<WbSelectList<int>>
{
}
