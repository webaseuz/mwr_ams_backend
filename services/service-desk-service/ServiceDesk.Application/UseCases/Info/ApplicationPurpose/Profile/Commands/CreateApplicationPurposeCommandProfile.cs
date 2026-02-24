using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ServiceDesk.Application.UseCases.DeviceModels;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

class CreateApplicationPurposeCommandProfile : Profile
{
    public CreateApplicationPurposeCommandProfile()
    {
        CreateMap<CreateApplicationPurposeCommand, ApplicationPurpose>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
