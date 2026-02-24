using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingFileDtoProfile :
    Profile
{
    public TransportSettingFileDtoProfile()
    {
        CreateMap<TransportSettingFile, TransportSettingFileDto>();
    }
}
