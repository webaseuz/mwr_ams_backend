using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Countries;

public class CountryTranslateCommand :
    TranslateCommand<CountryTranslateCommand, CountryTranslate, TranslateColumn>
{ }
