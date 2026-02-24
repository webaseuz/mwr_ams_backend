using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Banks;

public class BankTranslateCommand :
    TranslateCommand<BankTranslateCommand, BankTranslate, TranslateColumn>
{ }
