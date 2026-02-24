using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class UpdateServiceApplicationCommandProfile : Profile
{
	public UpdateServiceApplicationCommandProfile()
	{
		CreateMap<UpdateServiceApplicationCommand, ServiceApplication>()
                 .ForMember(src => src.ServiceApplicationFiles, conf => conf.Ignore());
    }
}
