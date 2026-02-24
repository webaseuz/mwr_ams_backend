using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Bms.WEBASE.Swagger;

public class SwaggerExcludeFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema?.Properties == null || context.Type == null)
            return;

        foreach (PropertyInfo item in from t in context.Type.GetProperties()
                                      where t.GetCustomAttribute<SwaggerExcludeAttribute>() != null || t.GetCustomAttribute<System.Text.Json.Serialization.JsonIgnoreAttribute>() != null || t.GetCustomAttribute<Newtonsoft.Json.JsonIgnoreAttribute>() != null
                                      select t)
        {
            if (schema.Properties.ContainsKey(item.Name))
                schema.Properties.Remove(item.Name);
        }
    }
}
