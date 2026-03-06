namespace Erp.Service.Adm.Application;

public interface IPasswordHasher
{
    bool Validate(string hash, string password, string salt);
    string Compute(string input);
}
