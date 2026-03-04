using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_insurance_type_translate")]
public class InsuranceTypeTranslate :
        BaseTranslateEntity<InsuranceTypeTranslate, TranslateColumn, int, InsuranceType>
{

}
