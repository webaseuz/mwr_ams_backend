using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingFileCommandProfile :
    Profile
{
    public UpdateTransportSettingFileCommandProfile()
    {
        CreateMap<UpdateTransportSettingFileCommand, TransportSettingFile>();
    }
}
