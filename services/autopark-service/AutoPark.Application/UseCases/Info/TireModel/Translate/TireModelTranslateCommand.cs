using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TireModels;

public class TireModelTranslateCommand :
    TranslateCommand<TireModelTranslateCommand, TireModelTranslate, TranslateColumn>
{
}
