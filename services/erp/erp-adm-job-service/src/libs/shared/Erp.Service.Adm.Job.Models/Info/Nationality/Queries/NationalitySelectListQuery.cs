using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class NationalitySelectListQuery : IRequest<WbSelectList<int, NationalitySelectListDto>>
{

}
