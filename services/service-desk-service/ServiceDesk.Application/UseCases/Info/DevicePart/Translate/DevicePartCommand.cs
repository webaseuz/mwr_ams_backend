using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class DevicePartTranslateCommand :
    TranslateCommand<DevicePartTranslateCommand, DevicePartTranslate, TranslateColumn>
{ }
