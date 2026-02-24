using Bms.WEBASE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.Application.UseCases.Enum.PlasticCardTypes;

public class PlasticCardTypeSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
