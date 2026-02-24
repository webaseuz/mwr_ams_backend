using Bms.Core.Application;
using Bms.Core.Domain;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Banks;

public class BankTranslateCommand :
    TranslateCommand<BankTranslateCommand, BankTranslate, TranslateColumn>
{ }
