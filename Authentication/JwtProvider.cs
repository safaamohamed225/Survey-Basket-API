
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SurveyBasket.Authentication;

public class JwtProvider(IConfiguration configuration, IOptions<JwtOptions> options) : IJwtProvider
{

    private readonly JwtOptions _options = options.Value;
    public (string token, int expillresIn) GenerateToken(ApplicationUser user)
    {
        Claim[] claims =
            [
             new(JwtRegisteredClaimNames.Sub,user.Id),
             new(JwtRegisteredClaimNames.Email,user.Email!),
             new(JwtRegisteredClaimNames.GivenName, user.FirstName),
             new(JwtRegisteredClaimNames.FamilyName, user.LastName),
             new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            ];

        var jwtSettings = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();

        var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
        var signCredentials = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
             issuer: _options.Issuer,
             audience: _options.Audience,
             claims: claims,
             expires: DateTime.UtcNow.AddMinutes(_options.ExpiryMinutes),
             signingCredentials: signCredentials
            );
        return (token: new JwtSecurityTokenHandler().WriteToken(token),  _options.ExpiryMinutes * 60);
    }

    public string? ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {

                IssuerSigningKey = symmetricSecuritykey,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            return jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value;
        }
        catch
        {
            return null;
        }
    }
}
