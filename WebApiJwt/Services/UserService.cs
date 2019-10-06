using System.Collections.Generic;
using WebApiJwt.Models;

namespace WebApiJwt.Services
{
    public class UserService : IUserService
    {
        public User GetUser(User user)
        {
            //Check user from database
            if (user.Username == "myusername" && user.Password == "mypassword")
            {
                //Get user roles from database
                user.Roles = new List<string> { "Administrator", "Manager" };
                return user;
            }

            return null;
        }
    }
}