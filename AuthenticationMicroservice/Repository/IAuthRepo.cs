using AuthenticationMicroservice.Models;

namespace AuthenticationMicroservice.Repository
{
    public interface IAuthRepo
    {


        Task<UserDetail> Register(UserDetail user);
        Task<UserDetail> Login(/*int id,*/ string username, string password);
        Task<bool> UserExists(string username);
    }
}
