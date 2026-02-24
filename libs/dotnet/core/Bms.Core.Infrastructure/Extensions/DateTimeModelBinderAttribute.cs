using Microsoft.AspNetCore.Mvc;

namespace Bms.Core.Infrastructure;

public class DateTimeModelBinderAttribute : ModelBinderAttribute
{
    public string DateFormat { get; set; }

    public DateTimeModelBinderAttribute()
        : base(typeof(DateTimeModelBinder))
    {
    }
}