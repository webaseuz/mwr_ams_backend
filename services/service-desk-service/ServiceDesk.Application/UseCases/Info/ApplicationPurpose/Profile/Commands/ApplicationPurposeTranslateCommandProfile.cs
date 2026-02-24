using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ServiceDesk.Application.UseCases.DeviceModels;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

public class ApplicationPurposeTranslateCommandProfile : Profile
{
    public ApplicationPurposeTranslateCommandProfile()
    {
        CreateMap<ApplicationPurposeTranslateCommand, ApplicationPurposeTranslate>();
    }
}
