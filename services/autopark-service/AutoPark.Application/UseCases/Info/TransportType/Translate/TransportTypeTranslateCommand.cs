using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TransportTypes;

public class TransportTypeTranslateCommand :
    TranslateCommand<TransportTypeTranslateCommand, TransportTypeTranslate, TranslateColumn>
{
}
