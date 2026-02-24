using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Nationalities;

public class NationalityTranslateCommand :
    TranslateCommand<NationalityTranslateCommand, NationalityTranslate, TranslateColumn>
{ }
