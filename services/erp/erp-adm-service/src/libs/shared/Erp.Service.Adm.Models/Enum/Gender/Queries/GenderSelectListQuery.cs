using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class GenderSelectListQuery : IRequest<WbSelectList<int>>
{
}