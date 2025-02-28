using System.IdentityModel.Tokens.Jwt;

namespace ImmobileApp.API.Service
{
    public class AuthenticationService
    {
        private readonly HttpContext _context;
        public AuthenticationService(HttpContext context)
        {
            _context = context;
        }

        public string userId()
        {
            var authentication = _context.Request.Headers.Authorization.ToString();
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = authentication["Bearer".Length..].Trim();

            var jwtToken = tokenHandler.ReadJwtToken(token);
            return jwtToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;
        }
    }
}
