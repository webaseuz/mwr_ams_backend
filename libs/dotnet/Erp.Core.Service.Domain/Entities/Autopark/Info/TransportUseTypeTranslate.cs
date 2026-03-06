using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_transport_use_type_translate", Schema = "autopark")]
public class TransportUseTypeTranslate :
    BaseTranslateEntity<TransportUseTypeTranslate, TranslateColumn, int, TransportUseType>
{

}
