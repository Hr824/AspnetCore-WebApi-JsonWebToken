using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApiJwt.Models;


namespace WebApiJwt.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // Return a basic Json Web Token
        public string GetToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(_configuration["Api:SecurityKey"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GetClaimsIdentity(user),
                Expires = DateTime.Now.AddMinutes(10),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }


        // Return an encrypted Json Web Token
        public string GetEncryptedToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(_configuration["Api:SecurityKey"]));
            var cryptKey = new SymmetricSecurityKey(Convert.FromBase64String(_configuration["Api:CryptKey"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GetClaimsIdentity(user),
                Expires = DateTime.Now.AddMinutes(10),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
                EncryptingCredentials = new EncryptingCredentials(cryptKey, JwtConstants.DirectKeyUseAlg, SecurityAlgorithms.Aes256CbcHmacSha512)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtstoken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(jwtstoken);

            return token;
        }


        private ClaimsIdentity GetClaimsIdentity(User user)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Username));

            foreach (string role in user.Roles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return claimsIdentity;
        }
    }
}