using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("hl_position_translate", Schema = "adm")]
public class PositionTranslate :
    BaseTranslateEntity<PositionTranslate, TranslateColumn, int, Position>
{

}
