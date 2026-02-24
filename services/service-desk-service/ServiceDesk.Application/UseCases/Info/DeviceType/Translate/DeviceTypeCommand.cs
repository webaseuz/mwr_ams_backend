using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class DeviceTypeTranslateCommand :
    TranslateCommand<DeviceTypeTranslateCommand, DeviceTypeTranslate, TranslateColumn>
{ }
