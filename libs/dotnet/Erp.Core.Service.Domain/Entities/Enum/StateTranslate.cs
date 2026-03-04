using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("enum_state_translate")]
public class StateTranslate :
    BaseTranslateEntity<StateTranslate, TranslateColumn, int, State>
{

}
