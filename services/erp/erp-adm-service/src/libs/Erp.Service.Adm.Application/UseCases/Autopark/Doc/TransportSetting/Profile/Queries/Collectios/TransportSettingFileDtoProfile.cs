using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportSettingFileDtoProfile : Profile
{
    public TransportSettingFileDtoProfile()
    {
        CreateMap<TransportSettingFile, TransportSettingFileDto>();
    }
}
