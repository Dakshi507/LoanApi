using LoanApi.Models;

namespace LoanApi.Repository
{
    public interface IUserRepo
    {
        Task<List<Userdetail>> GetUserList();
        Task<Userdetail> GetUserByUserId(int userid);

    }
}
         