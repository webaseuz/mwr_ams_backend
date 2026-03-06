using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_bank_translate", Schema = "adm")]
public class BankTranslate :
    BaseTranslateEntity<BankTranslate, TranslateColumn, int, Bank>
{

}
