using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_district_translate")]
public class DistrictTranslate :
    BaseTranslateEntity<DistrictTranslate, TranslateColumn, int, District>
{

}
