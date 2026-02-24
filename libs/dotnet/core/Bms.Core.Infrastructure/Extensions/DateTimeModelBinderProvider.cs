using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Bms.Core.Infrastructure;

public class DateTimeModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (DateTimeModelBinder.SUPPORTED_TYPES.Contains(context.Metadata.ModelType))
        {
            return new BinderTypeModelBinder(typeof(DateTimeModelBinder));
        }

        return null;
    }
}