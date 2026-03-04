using Erp.Core;
using Erp.Core.Models;
﻿namespace Erp.Service.Adm.Models;
public class TableDto : ISysEntity<int>
{
    public int Id { get; set; }
    public int TableId { get; } = TableIdConst.ADM_SYS_TABLE;
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string DbTableName { get; set; }
    public string DbSchemaName { get; set; }
    public string TableType { get; set; }

    public List<FileConfigDto> FileConfigs { get; set; }
    public List<TableTranslateDto> Translates { get; set; } = new();
}
