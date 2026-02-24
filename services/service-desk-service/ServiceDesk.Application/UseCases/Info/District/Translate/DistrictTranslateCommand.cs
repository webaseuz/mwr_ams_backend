using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Districts;

public class DistrictTranslateCommand :
    TranslateCommand<DistrictTranslateCommand, DistrictTranslate, TranslateColumn>
{}
