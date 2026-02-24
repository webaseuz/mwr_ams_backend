using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

public class ApplicationPurposeBriefDto
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string OrderCode { get; set; }
    public int DeviceTypeId { get; set; }
    public string DeviceTypeName { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; }

    public bool CanModify { get; set; }
    public bool CanDelete { get; set; }
    public bool CanView { get; set; }
}
