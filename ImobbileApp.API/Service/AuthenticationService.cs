using System.IdentityModel.Tokens.Jwt;
using ImmobileApp.Exception;

namespace ImmobileApp.API.Service
{
    public class AuthenticationService
    {
        private readonly HttpContext _context;
        public AuthenticationService(HttpContext context)
        {
            _context = context;
        }

        public Guid userId()
        {
            var authorizationHeader = _context.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                throw new UnauthorizedException();
            }

            var token = authorizationHeader.Substring("Bearer ".Length).Trim();
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var jwtToken = tokenHandler.ReadJwtToken(token);

                var userIdClaim = jwtToken.Claims
                    .FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub);

                if (userIdClaim == null)
                {
                    throw new UnauthorizedException();
                }

                return new Guid(userIdClaim.Value); // <- vai te dar o GUID certinho
            }
            catch
            {
                throw new UnauthorizedException();
            }

        }

    }
}
