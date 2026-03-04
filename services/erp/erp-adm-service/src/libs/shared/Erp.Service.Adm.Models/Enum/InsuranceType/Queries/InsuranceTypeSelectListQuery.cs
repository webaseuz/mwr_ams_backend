using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class InsuranceTypeSelectListQuery : IRequest<WbSelectList<int>>
{
}