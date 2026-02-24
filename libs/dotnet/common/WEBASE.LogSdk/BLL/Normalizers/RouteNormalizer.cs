using System.Text.RegularExpressions;

namespace WEBASE.LogSdk.BLL.Normalizers;

public class RouteNormalizer
{
    /// <summary>
    /// Normalizes the given route by replacing GUIDs and numeric values with placeholders.
    /// </summary>
    private static readonly Regex GuidPattern = new Regex(@"\b[a-fA-F0-9]{8}\b-[a-fA-F0-9]{4}\b-[a-fA-F0-9]{4}\b-[a-fA-F0-9]{4}\b-[a-fA-F0-9]{12}\b", RegexOptions.Compiled);
    private static readonly Regex NumericPattern = new Regex(@"\b\d+\b", RegexOptions.Compiled);

    /// <summary>
    /// Normalizes the URL path by replacing GUIDs and numeric IDs with {guid} and {id} respectively.
    /// </summary>
    /// <param name="requestPath"></param>
    /// <returns></returns>
    public static string NormalizeURLPath(string requestPath)
    {
        // Replace GUIDs with {guid}
        var normalizedPath = GuidPattern.Replace(requestPath, "{guid}");

        // Replace numeric IDs with {id}
        normalizedPath = NumericPattern.Replace(normalizedPath, "{id}");

        return normalizedPath;
    }
}
