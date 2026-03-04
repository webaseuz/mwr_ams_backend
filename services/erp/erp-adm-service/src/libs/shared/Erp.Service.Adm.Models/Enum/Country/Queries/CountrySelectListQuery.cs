using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class CountrySelectListQuery : IRequest<WbSelectList<int>>
{
}