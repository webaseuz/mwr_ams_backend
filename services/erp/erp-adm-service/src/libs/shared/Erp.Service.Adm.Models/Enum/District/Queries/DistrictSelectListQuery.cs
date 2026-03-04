using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class DistrictSelectListQuery : IRequest<WbSelectList<int>>
{
    public int? RegionId { get; set; }
}