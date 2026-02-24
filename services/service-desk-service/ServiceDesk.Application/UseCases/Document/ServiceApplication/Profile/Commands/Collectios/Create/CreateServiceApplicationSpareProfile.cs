using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class CreateServiceApplicationSpareProfile : Profile
{
	public CreateServiceApplicationSpareProfile()
	{
        CreateMap<CreateServiceApplicationSpareCommand, ServiceApplicationSpare>();
        CreateMap<ServiceApplicationSpareDto, ServiceApplicationSpare>();
    }
}
