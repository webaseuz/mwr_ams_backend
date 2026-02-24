using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Nationalities;

public class NationalityTranslateCommand :
    TranslateCommand<NationalityTranslateCommand, NationalityTranslate, TranslateColumn>
{ }
