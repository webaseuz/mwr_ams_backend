using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_transport_type_translate", Schema = "autopark")]
public class TransportTypeTranslate :
     BaseTranslateEntity<TransportTypeTranslate, TranslateColumn, int, TransportType>
{

}
