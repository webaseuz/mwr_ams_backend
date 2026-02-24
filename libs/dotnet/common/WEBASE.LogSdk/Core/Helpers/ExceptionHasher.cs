using System.Security.Cryptography;
using System.Text;

namespace WEBASE.LogSdk.Core.Helpers;

/// <summary>
/// This class is used to generate a hash for exception titles.
/// </summary>
public class ExceptionHasher
{
    /// <summary>
    /// Berilgan exception matnidan (maks. 100 belgi) MD5 hash yaratadi.
    /// Bu hash, xatolikni identifikatsiya qilish yoki logda qayta yozmaslik uchun ishlatiladi.
    /// </summary>
    /// <param name="exsaptionTitle">Exceptionning sarlavhasi yoki matni</param>
    /// <returns>MD5 hash ko‘rinishida string</returns>

    public static string Generate(string exsaptionTitle)
    {
        // maxs lenth 100
        string limitedTitle = exsaptionTitle.Length > 100 ? exsaptionTitle.Substring(0, 100) : exsaptionTitle;

        // Create a new instance of the MD5CryptoServiceProvider
        using (var md5 = MD5.Create())
        {
            // Convert the string to a byte array and compute the hash
            byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(limitedTitle));

            // Convert the byte array to a hexadecimal string
            StringBuilder hashString = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashString.Append(hashBytes[i].ToString("x2"));
            }

            // Return the hexadecimal string
            return hashString.ToString();
        }
    }
}
