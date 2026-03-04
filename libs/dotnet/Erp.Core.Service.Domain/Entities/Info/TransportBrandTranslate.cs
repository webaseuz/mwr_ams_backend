using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("info_transport_brand_translate")]
public class TransportBrandTranslate :
    BaseTranslateEntity<TransportBrandTranslate, TranslateColumn, int, TransportBrand>
{

}
