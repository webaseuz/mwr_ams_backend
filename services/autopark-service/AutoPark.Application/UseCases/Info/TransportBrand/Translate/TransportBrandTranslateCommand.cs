using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TransportBrands;

public class TransportBrandTranslateCommand :
    TranslateCommand<TransportBrandTranslateCommand, TransportBrandTranslate, TranslateColumn>
{
}
