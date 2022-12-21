using LoanApi.DTO;
using LoanApi.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace LoanApi.Repository
{
    public interface ILoanRepo
    {
        Task<Loandetail> AddLoan(Loandetail loandetail);
        Task<List<Loandetail>> GetLoanList();
        Task<List<Loandetail>> GetLoanByUSerId(int userid);
        Task<Loandetail> GetLoanByLoanId(int loanid);
        Task<Loandetail> UpdateLoan(Loandetail loandetail);
        //Task<List<AlldetailsDTO>> AllDataList();

        //Task<Loandetail> UpdateLoan(int loanno, JsonPatchDocument loandetail);
    }
}

