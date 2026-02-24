using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Citizenships;

public class CitizenshipTranslateCommand :
    TranslateCommand<CitizenshipTranslateCommand, CitizenshipTranslate, TranslateColumn>
{ }
