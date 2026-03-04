using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class DocumentTypeSelectListQuery : IRequest<WbSelectList<int, DocumentTypeSelectListDto>>
{

}
