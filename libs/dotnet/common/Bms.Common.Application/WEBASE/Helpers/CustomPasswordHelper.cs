namespace Bms.WEBASE.Helpers;

public class CustomPasswordHelper
{
    public string HashPassword(string password, string salt)
        => HashHelper.ComputeSaltedHash(password, salt);

    public bool ValidateHashedPassword(string hashedPassword,
                                       string providedPassword,
                                       string salt)
    {
        if (string.Equals(hashedPassword, HashHelper.ComputeSaltedHash(providedPassword, salt), StringComparison.Ordinal))
            return true;

        return false;
    }
}
