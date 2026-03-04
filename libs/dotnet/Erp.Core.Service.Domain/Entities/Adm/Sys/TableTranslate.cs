using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("sys_table_translate", Schema = "adm")]
public class TableTranslate : BaseTranslateEntity<TableTranslate, TranslateColumn, int, Table>
{
}
