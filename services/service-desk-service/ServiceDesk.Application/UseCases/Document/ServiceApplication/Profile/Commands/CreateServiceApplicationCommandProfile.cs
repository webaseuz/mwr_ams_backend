using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class CreateServiceApplicationCommandProfile : Profile
{
	public CreateServiceApplicationCommandProfile()
	{
		CreateMap<CreateServiceApplicationCommand, ServiceApplication>()
                 .ForMember(src => src.ServiceApplicationFiles, conf => conf.Ignore());
    }
}
