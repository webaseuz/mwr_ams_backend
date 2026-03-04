using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class CountrySelectListQuery : IRequest<WbSelectList<int, CountrySelectListDto>>
{

}
