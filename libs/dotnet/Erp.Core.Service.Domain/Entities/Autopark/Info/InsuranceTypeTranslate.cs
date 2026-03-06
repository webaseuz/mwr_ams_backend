using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_insurance_type_translate", Schema = "autopark")]
public class InsuranceTypeTranslate :
        BaseTranslateEntity<InsuranceTypeTranslate, TranslateColumn, int, InsuranceType>
{

}
