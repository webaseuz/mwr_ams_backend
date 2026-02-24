using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Currencies;

public class CurrencyTranslateCommand :
    TranslateCommand<CurrencyTranslateCommand, CurrencyTranslate, TranslateColumn>
{ }
