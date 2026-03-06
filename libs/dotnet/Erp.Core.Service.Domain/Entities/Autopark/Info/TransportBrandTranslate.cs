using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_transport_brand_translate", Schema = "autopark")]
public class TransportBrandTranslate :
    BaseTranslateEntity<TransportBrandTranslate, TranslateColumn, int, TransportBrand>
{

}
