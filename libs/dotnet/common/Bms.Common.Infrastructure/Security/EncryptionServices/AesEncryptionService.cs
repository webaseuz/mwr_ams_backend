using System.Security.Cryptography;
using System.Text;
using WEBASE.Security.Abstraction;

namespace WEBASE.Security;

public class AesEncryptionService :
    IEncryptionService
{
    //Key ga hushyor bo'lish talab qilinadi chunki shifrlangan malumot faqat o'sha key bilangina ochiladi holos
    //key - 16,24,32 uzunlikdan biri bo'lishi talab qilinadi
    private readonly byte[] Key;
    private readonly EncryptionConfig _config;

    public AesEncryptionService(EncryptionConfig config) // appsettings yoki secrets.json da saqlab o'sha yerdan beriladi
    {
        _config = config;
        byte[] keyBytes = Encoding.UTF8.GetBytes(_config.Key);

        if (keyBytes.Length != 16 &&
            keyBytes.Length != 24 &&
            keyBytes.Length != 32)
            throw new ArgumentException("Key must be 16, 24, or 32 symbol (128, 192, or 256 bits)");

        Key = keyBytes;
    }

    public string Encrypt(string data)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            byte[] iv = new byte[aes.BlockSize / 8];
            RandomNumberGenerator.Fill(iv);
            aes.IV = iv;

            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(iv, 0, iv.Length); // IV ni malumot ning boshida saqlash uchun shunaqa qilingan.Bu dishfrlash uchun kerak bo'lgan vektor ni kalitning o'zida saqlash degani.Lekin uning o'zi bilan to'liq dishfrlab bo'lmaydi buning uchun KEY talab qilinadi u esa dasturning o'zida appsettingsda saqlanadi

                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                using (StreamWriter sw = new StreamWriter(cs, Encoding.UTF8))
                    sw.Write(data);

                return Convert.ToBase64String(ms.ToArray()); // IV + data
            }
        }
    }

    public string Decrypt(string data)
    {
        byte[] buffer = Convert.FromBase64String(data);

        using (MemoryStream ms = new MemoryStream(buffer))
        {
            byte[] iv = new byte[16];

            if (ms.Read(iv, 0, iv.Length) != iv.Length)
                throw new CryptographicException("Invalid IV length");

            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs, Encoding.UTF8))
                    return sr.ReadToEnd();
            }
        }
    }
}
