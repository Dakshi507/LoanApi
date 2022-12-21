using AuthenticationMicroservice.Context;
using AuthenticationMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationMicroservice.Repository
{
    public class AuthRepo : IAuthRepo
    {
        private readonly AppDbContext _context;



        public AuthRepo(AppDbContext context)
        {
            _context = context;
        }

       

        public async Task<UserDetail> Login(/*int id,*/ string username, string password)
        {
            var user = await _context.Userdetails.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
                return null;



            if (password != user.Password)
                return null;

            


            return user;
        }

        public async Task<UserDetail> Register(UserDetail user)
        {



            await _context.Userdetails.AddAsync(user);
            await _context.SaveChangesAsync();



            return user;
        }











        public async Task<bool> UserExists(string username)
        {
            if (await _context.Userdetails.AnyAsync(x => x.UserName == username))
                return true;
            return false;
        }
    }
}
