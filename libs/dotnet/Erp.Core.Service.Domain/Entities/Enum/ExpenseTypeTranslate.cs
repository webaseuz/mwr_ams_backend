using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("enum_expense_type_translate")]
public class ExpenseTypeTranslate :
    BaseTranslateEntity<ExpenseTypeTranslate, TranslateColumn, int, ExpenseType>
{
}
