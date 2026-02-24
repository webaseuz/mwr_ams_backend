namespace Bms.WEBASE.Storage;

public class FileStorageException : Exception
{
    public FileStorageException()
    { }

    public FileStorageException(string message) : base(message) { }
}
