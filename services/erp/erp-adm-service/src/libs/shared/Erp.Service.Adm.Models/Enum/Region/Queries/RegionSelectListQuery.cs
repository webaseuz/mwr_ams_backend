using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class RegionSelectListQuery : IRequest<WbSelectList<int>>
{
    public int? CountryId { get; set; }
}