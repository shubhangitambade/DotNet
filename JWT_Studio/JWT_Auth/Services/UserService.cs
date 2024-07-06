
using Microsoft.Extensions.Options;
using System.Security.Claims;
using JWT_Auth.Entities;
using JWT_Auth.Helper;
using JWT_Auth.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JWT_Auth.Services
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Ganesh", LastName = "Shinde",
                        Username = "ganesh", Password = "test" },
             new User { Id = 2, FirstName = "Ankur", LastName = "Prasad",
                        Username = "ankur", Password = "test" },
             new User { Id = 3, FirstName = "Neha", LastName = "Bhor",
                        Username = "neha", Password = "test" },
             new User { Id = 4, FirstName = "Vishwambhar", LastName = "Kapre",
                        Username = "vishwambhar", Password = "test" }
        };

        private readonly AppSetting _appSetting;
        public UserService(IOptions<AppSetting> appSettings)
        {
            _appSetting = appSettings.Value;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)


            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
         public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}
