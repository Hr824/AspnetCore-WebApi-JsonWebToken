using WebApiJwt.Models;

namespace WebApiJwt.Services
{
    public interface IUserService
    {
        User GetUser(User user);
    }
}