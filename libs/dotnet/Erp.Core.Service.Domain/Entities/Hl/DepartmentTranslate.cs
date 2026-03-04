using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("hl_department_translate")]
public class DepartmentTranslate :
   BaseTranslateEntity<DepartmentTranslate, TranslateColumn, int, Department>
{

}
