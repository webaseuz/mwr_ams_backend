using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TireSizeSelectListQuery : IRequest<WbSelectList<int>>
{
}