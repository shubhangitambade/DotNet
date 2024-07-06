using RoleBasedSecureApp.Entities;
using RoleBasedSecureApp.Model;
using RoleBasedSecureApp.Helper;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace RoleBasedSecureApp.Services
{
    public class UserService : IUserService
    {
        //List is made using Property Initialization
        private List<User> _users = new List<User>
        {

            new User { Id = 1, FirstName = "Swarali", LastName = "L", Username = "swarali", Password = "swarali", Role = Role.Admin },
            new User { Id = 2, FirstName = "Ganesh", LastName = "S", Username = "ganesh", Password = "ganesh", Role = Role.User } ,
            new User { Id = 3, FirstName = "Rutuja", LastName = "T", Username = "rutuja", Password = "rutuja", Role = Role.User },
            new User { Id = 4, FirstName = "Vishwambhar", LastName = "K", Username = "vishwambhar", Password = "vishwambhar", Role = Role.User },
            new User { Id = 5, FirstName = "Rohit", LastName = "W", Username = "rohit", Password = "rohit", Role = Role.Admin },

        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)//DI [? Why need to use IOptions<AppSettings> and ? appSettings.Value]
        {
            _appSettings = appSettings.Value;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }


        public string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()),
                                                     new Claim("role",user.Role)}),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                           SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
