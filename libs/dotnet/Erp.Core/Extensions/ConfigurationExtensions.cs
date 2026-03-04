using System.Collections;
using Microsoft.Extensions.Configuration;

namespace Erp.Core;
public static class ConfigurationExtensions
{
    public static void AlterEnvironmentConfiguration(this IConfiguration configuration)
    {
        foreach (var kvp in configuration.AsEnumerable())
        {
            if (kvp.Value != null && kvp.Value.Contains("${"))
            {
                var updatedValue = kvp.Value;

                foreach (var env in Environment.GetEnvironmentVariables().Cast<DictionaryEntry>())
                {
                    var placeholder = $"${{{env.Key}}}";

                    if (updatedValue.Contains(placeholder))
                    {
                        updatedValue = updatedValue.Replace(placeholder, env.Value?.ToString());
                    }
                }

                if (updatedValue != kvp.Value)
                {
                    configuration[kvp.Key] = updatedValue;
                }
            }
        }
    }
}
