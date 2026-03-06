using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("enum_inspection_type_translate", Schema = "autopark")]
public class InspectionTypeTranslate :
    BaseTranslateEntity<InspectionTypeTranslate, TranslateColumn, int, InspectionType>
{
  
}
