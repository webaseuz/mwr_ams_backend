namespace WEBASE.Security.Abstraction;

public interface ICredSourceService
{
    /// <summary>
    /// Get credential information from source (Cookie or something like that)
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    string Get(string key);

    /// <summary>
    /// Set credential information to source
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Set(string key, string value);

    /// <summary>
    /// Remove credential information by key from source
    /// </summary>
    /// <param name="key"></param>
    void Remove(string key);
}
