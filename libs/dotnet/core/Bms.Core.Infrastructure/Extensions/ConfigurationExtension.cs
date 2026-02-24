using Microsoft.Extensions.Configuration;
using System.Collections;

namespace Bms.Core.Infrastructure;

public static class ConfigurationExtension
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
                    var placeHolder = $"${{{env.Key}}}";

                    if (updatedValue.Contains(placeHolder))
                        updatedValue = updatedValue.Replace(placeHolder, env.Value.ToString());
                }

                if (updatedValue != kvp.Value)
                    configuration[kvp.Key] = updatedValue;
            }
        }
    }
}
