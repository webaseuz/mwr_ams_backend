using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class FileConfigGetListQuery : WbSortFilterPageOptions,
    IRequest<WbPagedResult<FileConfigBriefDto>>
{
}
