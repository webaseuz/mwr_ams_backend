using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using WEBASE.Security.Abstraction;

namespace Bms.WEBASE.Security;

public class JwtTokenService :
    TokenService,
    IJwtTokenService
{
    private readonly JwtConfig _config;
    protected virtual string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256;

    public JwtTokenService(JwtConfig config)
        => _config = config;

    public Claim[] GetClaims(string token)
    {
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

        var jwtToken = jwtSecurityTokenHandler.ReadJwtToken(token);

        return jwtToken?.Claims.ToArray() ?? Array.Empty<Claim>();
    }

    public TokenResult GenerateJwtToken(IEnumerable<Claim> claims)
        => GenerateJwtToken(claims, TimeSpan.FromMinutes(_config.Expires));

    public TokenResult GenerateJwtToken(IEnumerable<Claim> claims,
                                        TimeSpan expireInterval)
    {
        SigningCredentials signingCredentials =
            new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.SecretKey)),
                                   SecurityAlgorithm);

        string issuer = _config.Issuer;

        DateTime expires = DateTime.UtcNow.AddMinutes(expireInterval.TotalMinutes);

        JwtSecurityToken token = new JwtSecurityToken(issuer,
                                                      issuer,
                                                      claims,
                                                      null,
                                                      expires,
                                                      signingCredentials);

        return new TokenResult
        {
            ExpireAt = expires,
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        };
    }

    public override TokenResult GenerateToken(string userIdentity)
     => GenerateToken(userIdentity, TimeSpan.FromMinutes(_config.Expires));

    public override TokenResult GenerateToken(string userIdentity,
                                              TimeSpan expireInterval)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim("sub", userIdentity)
        };

        SigningCredentials signingCredentials =
            new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.SecretKey)),
                                   SecurityAlgorithm);

        string issuer = _config.Issuer;
        string issuer2 = _config.Issuer;

        int expireMinutes = (int)expireInterval.TotalMinutes;

        DateTime? expires = DateTime.UtcNow.AddMinutes(expireMinutes);

        JwtSecurityToken token = new JwtSecurityToken(issuer,
                                                      issuer2,
                                                      claims,
                                                      null,
                                                      expires,
                                                      signingCredentials);

        return new TokenResult
        {
            ExpireAt = token.ValidTo.ToLocalTime(),
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        };
    }

    public override bool ValidateToken(string token)
    {
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

        var validationParameters = new TokenValidationParameters
        {
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidIssuer = _config.Issuer,
            ValidAudience = _config.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.SecretKey))
        };

        try
        {
            SecurityToken validatedToken;

            var validateResult = ((IPrincipal)jwtSecurityTokenHandler.ValidateToken(token,
                                                                      validationParameters,
                                                                      out validatedToken));

            var isValid = validateResult.Identity.IsAuthenticated;

            isValid = validatedToken.ValidTo >= DateTime.UtcNow;

            return isValid;
        }
        catch (Exception)
        {
            return false;
        }
    }
}