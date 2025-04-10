using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Front.Helpers
{
    public static class TokenHelper
    {
        public static int? GetUserIdFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var nameIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "nameid");

            if (nameIdClaim != null && int.TryParse(nameIdClaim.Value, out var userId))
            {
                return userId;
            }

            return null;
        }
    }
}
