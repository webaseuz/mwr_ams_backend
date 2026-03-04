using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_transport_color_translate")]
public class TransportColorTranslate :
    BaseTranslateEntity<TransportColorTranslate, TranslateColumn, int, TransportColor>
{

}
