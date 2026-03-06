using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_transport_model_translate", Schema = "autopark")]
public class TransportModelTranslate :
    BaseTranslateEntity<TransportModelTranslate, TranslateColumn, int, TransportModel>
{

}
