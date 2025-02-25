using Microsoft.AspNetCore.Identity;

namespace EGWalks.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
