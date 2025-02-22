using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechLibray.Api.Domain.Entidades;

namespace TechLibray.Api.Infrastructure.Security.Tokens.Access;

public class JwtTokenGenerator
{
    public string Generate(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
        };
  
        var tokenDescript = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddMinutes(60),
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(SecurityKey(),
            SecurityAlgorithms.HmacSha256Signature)

        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescript);

        return tokenHandler.WriteToken(securityToken);
    }

    private SymmetricSecurityKey SecurityKey()
    {
        var signingkey = "zl9yP6y37ZTIe4Vx8sGvTje7paA3VqVr";

        Encoding.UTF8.GetBytes(signingkey);

        var symmetricKey = Encoding.UTF8.GetBytes(signingkey);

        return new SymmetricSecurityKey(symmetricKey);
    }
}