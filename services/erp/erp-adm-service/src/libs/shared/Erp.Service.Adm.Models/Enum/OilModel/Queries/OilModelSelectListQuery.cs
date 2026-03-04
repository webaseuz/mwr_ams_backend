using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class OilModelSelectListQuery : IRequest<WbSelectList<int>>
{
    public int? OilTypeId { get; set; }
}