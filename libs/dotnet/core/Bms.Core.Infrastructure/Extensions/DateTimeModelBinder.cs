using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bms.Core.Infrastructure;

public class DateTimeModelBinder : IModelBinder
{
    public static readonly Type[] SUPPORTED_TYPES = new Type[2]
    {
        typeof(DateTime),
        typeof(DateTime?)
    };

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException("bindingContext");
        }

        if (!SUPPORTED_TYPES.Contains(bindingContext.ModelType))
        {
            return Task.CompletedTask;
        }

        string modelName = GetModelName(bindingContext);
        ValueProviderResult value = bindingContext.ValueProvider.GetValue(modelName);
        if (value == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        bindingContext.ModelState.SetModelValue(modelName, value);
        string firstValue = value.FirstValue;
        if (string.IsNullOrEmpty(firstValue))
        {
            return Task.CompletedTask;
        }

        DateTime? dateTime = ParseDate(bindingContext, firstValue);
        bindingContext.Result = ModelBindingResult.Success(dateTime);
        return Task.CompletedTask;
    }
    private DateTime? ParseDate(ModelBindingContext bindingContext, string dateToParse)
    {
        string text = GetDateTimeModelBinderAttribute(bindingContext)?.DateFormat;
        if (string.IsNullOrEmpty(text))
        {
            return DateTimeHelper.ParseDateTime(dateToParse);
        }

        return DateTimeHelper.ParseDateTime(dateToParse, new string[1] { text });
    }
    private DateTimeModelBinderAttribute GetDateTimeModelBinderAttribute(ModelBindingContext bindingContext)
    {
        string modelName = GetModelName(bindingContext);
        if (!((from x in bindingContext.ActionContext.ActionDescriptor.Parameters
               where x.ParameterType == typeof(DateTime?)
               where (x.BindingInfo?.BinderModelName ?? x.Name).Equals(modelName)
               select x).FirstOrDefault() is ControllerParameterDescriptor controllerParameterDescriptor))
        {
            return null;
        }

        return (DateTimeModelBinderAttribute)controllerParameterDescriptor.ParameterInfo.GetCustomAttributes(typeof(DateTimeModelBinderAttribute), inherit: false).FirstOrDefault();
    }
    private string GetModelName(ModelBindingContext bindingContext)
    {
        if (!string.IsNullOrEmpty(bindingContext.BinderModelName))
        {
            return bindingContext.BinderModelName;
        }

        return bindingContext.ModelName;
    }
}