using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class DriverDocumentDtoProfile : Profile
{
    public DriverDocumentDtoProfile()
    {
        CreateMap<DriverDocument, DriverDocumentDto>()
            .ForMember(src => src.DocumentTypeName, conf => conf.MapFrom(ent => ent.DocumentType.FullName));
    }
}
