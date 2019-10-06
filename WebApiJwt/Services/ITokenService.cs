using WebApiJwt.Models;

namespace WebApiJwt.Services
{
    public interface ITokenService
    {
        string GetToken(User user);

        string GetEncryptedToken(User user);
    }
}