using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class UpdateServiceApplicationPartProfile : Profile
{
	public UpdateServiceApplicationPartProfile()
	{
		CreateMap<UpdateServiceApplicationPartCommand, ServiceApplicationPart>();
	}
}
