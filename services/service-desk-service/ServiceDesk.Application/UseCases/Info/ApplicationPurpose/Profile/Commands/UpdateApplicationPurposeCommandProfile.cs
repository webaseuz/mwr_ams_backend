using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

public class UpdateApplicationPurposeCommandProfile : Profile
{
    public UpdateApplicationPurposeCommandProfile()
    {
        CreateMap<UpdateApplicationPurposeCommand, ApplicationPurpose>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
