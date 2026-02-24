using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingFileCommandProfile :
    Profile
{
    public CreateTransportSettingFileCommandProfile()
    {
        CreateMap<CreateTransportSettingFileCommand, TransportSettingFile>();
    }
}
