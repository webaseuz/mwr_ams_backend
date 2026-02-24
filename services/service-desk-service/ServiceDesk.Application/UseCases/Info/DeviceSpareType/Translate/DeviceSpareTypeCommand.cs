using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class DeviceSpareTypeTranslateCommand :
    TranslateCommand<DeviceSpareTypeTranslateCommand, DeviceSpareTypeTranslate, TranslateColumn>
{ }
