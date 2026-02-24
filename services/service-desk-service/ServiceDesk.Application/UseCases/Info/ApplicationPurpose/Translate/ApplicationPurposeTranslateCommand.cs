using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using ServiceDesk.Application.UseCases.DeviceModels;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

public class ApplicationPurposeTranslateCommand :
    TranslateCommand<DeviceModelTranslateCommand, DeviceModelTranslate, TranslateColumn>
{
}
