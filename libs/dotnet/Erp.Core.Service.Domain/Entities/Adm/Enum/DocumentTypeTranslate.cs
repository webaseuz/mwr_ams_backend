using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("enum_document_type_translate", Schema = "adm")]
public class DocumentTypeTranslate :
    BaseTranslateEntity<DocumentTypeTranslate, TranslateColumn, int, DocumentType>
{
}
