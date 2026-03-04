namespace Erp.Core.Models;

/// <summary>
/// OpenXml (Excel, Word, PowerPoint) formatidagi fayllarni qaytarish uchun model.
/// </summary>
public class OpenXmlFileResult
{
    /// <summary>
    /// Foydalanuvchiga yuboriladigan fayl baytlari.
    /// </summary>
    public byte[] FileBytes { get; set; }

    /// <summary>
    /// Fayl nomi (masalan: Bayonotnoma_2025.xlsx).
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// Fayl MIME turi (masalan: application/vnd.openxmlformats-officedocument.spreadsheetml.sheet).
    /// </summary>
    public string ContentType { get; set; } = 
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

    /// <summary>
    /// Foydalanuvchiga faylni yuborish uchun tayyor holatda `OpenXmlFileResult` yaratish.
    /// </summary>
    public OpenXmlFileResult()
    {
    }

    public OpenXmlFileResult(string fileName, byte[] fileBytes)
    {
        FileName = fileName;
        FileBytes = fileBytes;
    }

    /// <summary>
    /// Faylni diskka saqlash uchun qulay yordamchi metod (debug yoki test uchun).
    /// </summary>
    public void SaveToFile(string path)
    {
        if (FileBytes == null || FileBytes.Length == 0)
            throw new InvalidOperationException("FileBytes is empty!");

        System.IO.File.WriteAllBytes(System.IO.Path.Combine(path, FileName), FileBytes);
    }
}
