using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TemporaryResidenceTypeSelectListQuery : IRequest<WbSelectList<int>>
{
}
