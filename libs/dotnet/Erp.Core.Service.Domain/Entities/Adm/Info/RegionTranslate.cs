using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_region_translate", Schema = "adm")]
public class RegionTranslate :
    BaseTranslateEntity<RegionTranslate, TranslateColumn, int, Region>
{

}
