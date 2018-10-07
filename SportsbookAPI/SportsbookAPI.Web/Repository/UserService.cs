using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SportsbookAPI.Web.Models;

namespace SportsbookAPI.Web.Repository
{
    public class UserService
    {
        private IEnumerable<User> _users;

        public UserService()
        {
            this._users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "Jack Admin",
                    Username = "admin",
                    Password = "secret123"
                }
            };
        }

        public string Login(LoginModel loginModel)
        {
            var user = _users.SingleOrDefault(x => x.Username == loginModel.Username && x.Password == loginModel.Password);

            // return null if user not found
            if (user == null)
                throw new InvalidCredentialException();

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("supersecret123supersecret");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
