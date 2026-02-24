using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Currencies;

public class CurrencyTranslateCommand :
    TranslateCommand<CurrencyTranslateCommand, CurrencyTranslate, TranslateColumn>
{ }
