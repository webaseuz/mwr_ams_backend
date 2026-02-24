using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Drivers;

public class DriverDocumentBriefDtoProfile : Profile
{
    public DriverDocumentBriefDtoProfile()
    {
        //DriverBriefDocumentDto
        CreateMap<DriverDocument, DriverDocumentBriefDto>()
            .ForMember(ent => ent.DocumentTypeName, conf => conf.MapFrom(ent => ent.DocumentType.FullName));
    }
}
