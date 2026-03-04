using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class InspectionTypeSelectListQuery : IRequest<WbSelectList<int>>
{
}