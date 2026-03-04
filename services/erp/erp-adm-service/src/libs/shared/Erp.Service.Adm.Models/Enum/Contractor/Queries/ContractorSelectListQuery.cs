using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class ContractorSelectListQuery : IRequest<WbSelectList<long>>
{
}