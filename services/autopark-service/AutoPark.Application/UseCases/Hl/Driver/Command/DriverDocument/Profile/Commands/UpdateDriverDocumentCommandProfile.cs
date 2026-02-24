using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Drivers;

public class UpdateDriverDocumentCommandProfile : Profile
{
    public UpdateDriverDocumentCommandProfile()
    {
        CreateMap<UpdateDriverDocumentCommand, DriverDocument>();
    }
}
