using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TransportColors;

public class TransportColorTranslateCommand :
    TranslateCommand<TransportColorTranslateCommand, TransportColorTranslate, TranslateColumn>
{
}
