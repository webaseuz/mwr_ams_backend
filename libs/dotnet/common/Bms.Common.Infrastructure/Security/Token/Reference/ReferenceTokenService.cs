using WEBASE.Security.Abstraction;

namespace Bms.WEBASE.Security;

public abstract class ReferenceTokenService :
    ITokenService,
    IReferenceTokenService
{
    public abstract TokenResult GenerateToken(string userIdentity);

    public abstract TokenResult GenerateToken(string userIdentity,
                                              TimeSpan expireInterval);
    public abstract bool ValidateToken(string token);
}