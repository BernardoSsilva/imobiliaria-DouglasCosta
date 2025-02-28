using ImmobileApp.Comunication.Responses.ShortResponses;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ImmobileApp.Security.Tokens
{
    public class TokenGenerator
    {
        private readonly string _jwtSecret;

        public TokenGenerator(IConfiguration configuration)
        {
            _jwtSecret = configuration["JwtSettings:Secret"] ?? throw new InvalidOperationException("JWT Secret is missing.");
        }

        public string Generate(UserShortResponseJson user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Profile, user.Role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new System.Security.Claims.ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }


        private SymmetricSecurityKey SecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));

    }
}
