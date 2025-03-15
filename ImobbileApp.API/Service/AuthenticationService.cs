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
            // Acessando o cabeçalho de autorização e garantindo que o valor é válido
            var authorizationHeader = _context.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedException();
            }

            // Extraindo o token JWT (removendo "Bearer ")
            var token = authorizationHeader.Substring("Bearer ".Length).Trim();

            // Criando o handler de token JWT
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var jwtToken = tokenHandler.ReadJwtToken(token);

                // Pegando o valor da claim "sub" (subject) que é o id do usuário
                var userIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub);

                if (userIdClaim == null)
                {
                    throw new UnauthorizedException();
                }

                // Retornando o GUID do usuário
                return new Guid(userIdClaim.Value);
            }
            catch
            {
                throw new UnauthorizedException();
            }
        }
    }
}
