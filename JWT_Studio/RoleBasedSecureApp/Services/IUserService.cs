using RoleBasedSecureApp.Entities;
using RoleBasedSecureApp.Model;


namespace RoleBasedSecureApp.Services
{
    public interface IUserService
    {

        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
