using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class PlasticCardTypeSelectListQuery : IRequest<WbSelectList<int>>
{
}