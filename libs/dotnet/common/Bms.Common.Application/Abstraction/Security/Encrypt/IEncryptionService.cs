namespace WEBASE.Security.Abstraction;

public interface IEncryptionService
{
    string Encrypt(string data);
    string Decrypt(string data);
}