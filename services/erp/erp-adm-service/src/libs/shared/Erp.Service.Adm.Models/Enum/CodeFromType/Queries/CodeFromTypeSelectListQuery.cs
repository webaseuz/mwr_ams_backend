using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class CodeFromTypeSelectListQuery : IRequest<WbSelectList<int>>
{
}