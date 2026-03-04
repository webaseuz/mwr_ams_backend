using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class LiquidTypeSelectListQuery : IRequest<WbSelectList<int>>
{
}