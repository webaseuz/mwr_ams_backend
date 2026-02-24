using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Drivers;

public class DriverDocumentDtoProfile : Profile
{
    public DriverDocumentDtoProfile()
    {
        //DriverDocumentDto
        CreateMap<DriverDocument, DriverDocumentDto>()
            .ForMember(ent => ent.DocumentTypeName, conf => conf.MapFrom(ent => ent.DocumentType.FullName));
    }
}
