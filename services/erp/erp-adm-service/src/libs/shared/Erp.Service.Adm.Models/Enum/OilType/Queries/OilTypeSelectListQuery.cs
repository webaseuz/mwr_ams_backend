using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class OilTypeSelectListQuery : IRequest<WbSelectList<int>>
{
}