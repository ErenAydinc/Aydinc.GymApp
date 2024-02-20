using System.Security.Claims;

namespace Core.Security.JWT;

public class AccessToken
{
    public string Token { get; set; }
    public DateTime ExpirationDate { get; set; }
    public IList<Claim> Claims { get; set; }
    public AccessToken()
    {
        Token = string.Empty;
    }

    public AccessToken(string token, DateTime expirationDate, IList<Claim> claims)
    {
        Token = token;
        ExpirationDate = expirationDate;
        Claims = claims;
    }
}
