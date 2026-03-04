using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class FileConfigSelectListQuery : IRequest<WbSelectList<int>>
{
}
