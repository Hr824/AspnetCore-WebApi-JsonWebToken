using System.Collections.Generic;

namespace WebApiJwt.Models
{
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public List<string> Roles { get; set; }

        public User() { }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(string username, string password, List<string> roles)
        {
            Username = username;
            Password = password;
            Roles = roles;
        }
    }
}