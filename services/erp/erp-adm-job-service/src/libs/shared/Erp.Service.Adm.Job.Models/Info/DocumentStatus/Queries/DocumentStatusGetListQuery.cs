using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class DocumentStatusGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<DocumentStatusBriefDto>>
{ }
