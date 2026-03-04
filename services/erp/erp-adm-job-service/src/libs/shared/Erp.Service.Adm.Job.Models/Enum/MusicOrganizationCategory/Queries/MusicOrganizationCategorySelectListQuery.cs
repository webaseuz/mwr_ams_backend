using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class MusicOrganizationCategorySelectListQuery : IRequest<WbSelectList<int>>
{
}
