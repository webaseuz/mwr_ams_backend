using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class PositionDtoProfile : Profile
{
    public PositionDtoProfile()
    {
        CreateMap<Position, PositionDto>();
    }
}
