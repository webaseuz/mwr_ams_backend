using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_bank_translate")]
public class BankTranslate :
    BaseTranslateEntity<BankTranslate, TranslateColumn, int, Bank>
{

}
