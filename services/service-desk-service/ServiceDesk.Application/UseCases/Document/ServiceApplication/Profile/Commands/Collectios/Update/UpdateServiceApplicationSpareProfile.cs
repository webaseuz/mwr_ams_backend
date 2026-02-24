using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class UpdateServiceApplicationSpareProfile : Profile
{
	public UpdateServiceApplicationSpareProfile()
	{
        CreateMap<UpdateServiceApplicationSpareCommand, ServiceApplicationSpare>();
    }
}
