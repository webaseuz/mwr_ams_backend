using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class PresentTrackingInfoDtoProfile : Profile
{
    public PresentTrackingInfoDtoProfile()
    {
        CreateMap<PresentTrackingInfo, PresentTrackingInfoDto>();
    }
}
