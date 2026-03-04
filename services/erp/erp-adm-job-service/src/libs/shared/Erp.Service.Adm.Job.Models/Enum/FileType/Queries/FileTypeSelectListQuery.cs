using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class FileTypeSelectListQuery : IRequest<WbSelectList<int>>
{
}
