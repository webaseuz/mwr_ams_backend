using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("enum_transmission_box_type_translate")]
public class TransmissionBoxTypeTranslate
    : BaseTranslateEntity<TransmissionBoxTypeTranslate, TranslateColumn, int, TransmissionBoxType>
{

}
