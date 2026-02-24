using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class DeviceModelTranslateCommand :
    TranslateCommand<DeviceModelTranslateCommand, DeviceModelTranslate, TranslateColumn>
{ }
