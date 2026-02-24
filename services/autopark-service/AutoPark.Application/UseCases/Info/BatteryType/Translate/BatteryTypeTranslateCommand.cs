using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class BatteryTypeTranslateCommand :
    TranslateCommand<BatteryTypeTranslateCommand, BatteryType, TranslateColumn>
{ }
