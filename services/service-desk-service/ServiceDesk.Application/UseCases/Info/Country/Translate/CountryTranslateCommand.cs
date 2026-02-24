using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Countries;

public class CountryTranslateCommand :
    TranslateCommand<CountryTranslateCommand, CountryTranslate, TranslateColumn>
{}
