using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class CitizenshipTranslateCommand :
    TranslateCommand<CitizenshipTranslateCommand, CitizenshipTranslate, TranslateColumn>
{ }
