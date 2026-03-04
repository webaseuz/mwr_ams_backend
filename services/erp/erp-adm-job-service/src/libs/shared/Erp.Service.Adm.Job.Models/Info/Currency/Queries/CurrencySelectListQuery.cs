using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class CurrencySelectListQuery : IRequest<WbSelectList<int, CurrencySelectListDto>>
{

}
