using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Application.UseCases.DeviceModels;

namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

public class CreateApplicationPurposeCommand : IRequest<IHaveId<int>>
{
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string OrderCode { get; set; } = null!;
    public int DeviceTypeId { get; set; }
    public List<ApplicationPurposeTranslateCommand> Translates { get; set; } = new();
}
