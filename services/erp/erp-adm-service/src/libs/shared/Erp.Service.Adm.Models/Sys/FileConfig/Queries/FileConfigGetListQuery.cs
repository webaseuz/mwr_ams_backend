using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class FileConfigGetListQuery : WbSortFilterPageOptions,
    IRequest<WbPagedResult<FileConfigBriefDto>>
{
}
