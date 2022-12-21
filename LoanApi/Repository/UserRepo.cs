using LoanApi.Context;
using LoanApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanApi.Repository
{
    public class UserRepo : IUserRepo
    {

        private readonly LoanManagementDbContext _context;

        public UserRepo(LoanManagementDbContext context)
        {
            _context = context;
        }
        public async Task<Userdetail> GetUserByUserId(int userid)
        {
            try
            {
                Userdetail? userdetail = new Userdetail();
                userdetail = await _context.Userdetails.FirstOrDefaultAsync(u => u.UserId == userid);
                return userdetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Userdetail>> GetUserList()
        {
            try
            {
                List<Userdetail> userdetailslist = new List<Userdetail>();
                userdetailslist = await _context.Userdetails.Include(u => u.Loandetails).ToListAsync();
                return userdetailslist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
