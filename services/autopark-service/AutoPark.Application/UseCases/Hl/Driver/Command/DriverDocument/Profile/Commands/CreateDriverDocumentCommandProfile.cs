using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Drivers;

public class CreateDriverDocumentCommandProfile : Profile
{
    public CreateDriverDocumentCommandProfile()
    {
        CreateMap<CreateDriverDocumentCommand, DriverDocument>();
    }
}
