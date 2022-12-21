
using LoanApi.Context;
using LoanApi.DTO;
using LoanApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.ModelBinding;

namespace LoanApi.Repository
{
    public class LoanRepo : ILoanRepo
    {

        private readonly LoanManagementDbContext _context;

        public LoanRepo(LoanManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Loandetail> AddLoan(Loandetail loandetail)
        {
            try
            {
                _context.Loandetails.Add(loandetail);
                await _context.SaveChangesAsync();
                return loandetail;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<Loandetail>> GetLoanList()
        {
            try
            {
                List<Loandetail> loandetailslist = new List<Loandetail>();
                loandetailslist = await _context.Loandetails.Include(loan => loan.User).ToListAsync();
                return loandetailslist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Loandetail>> GetLoanByUSerId(int userid)
        {
            try
            {
                List<Loandetail> loandetailsfound = new List<Loandetail>();
                loandetailsfound = await _context.Loandetails.Include(loan => loan.User)
                    .Where(l => l.UserId == userid)
                    .ToListAsync();
                return loandetailsfound;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Loandetail> GetLoanByLoanId(int loanid)
        {
                try
                {
                    Loandetail? loandetailsfound = new Loandetail();
                    loandetailsfound = await _context.Loandetails.FirstOrDefaultAsync(l => l.Loannumber == loanid);
                    return loandetailsfound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }

        
        
        public async Task<Loandetail> UpdateLoan(Loandetail loandetail)
        {
            try
            {
                _context.Loandetails.Update(loandetail);
                await _context.SaveChangesAsync();
                return loandetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
        public async Task<List<AlldetailsDTO>> AllDataList()
        {
            try
            {
                List<AlldetailsDTO> Alldata = new List<AlldetailsDTO>();
                Alldata = await (from u in _context.Userdetails
                            join l in _context.Loandetails
                            on u.UserId equals l.UserId
                            select new AlldetailsDTO
                            {
                                UserId = u.UserId,
                                Firstname = u.Firstname,
                                Lastname = u.Lastname,
                                Username = u.Username,
                                Loanid = l.Loanid,
                                Loannumber = l.Loannumber,
                                Loanamount = l.Loanamount,
                                LoanTerm = l.LoanTerm,
                                Loantype = l.Loantype,
                                Propertyaddress = l.Propertyaddress
                            }).ToListAsync();
                //_context.Loandetails.Update(loandetail);
                //await _context.SaveChangesAsync();
                return Alldata;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        /*
                public async Task<Loandetail> UpdateLoan(int loanno, JsonPatchDocument loandetail)
                {
                    var loan = await _context.Loandetails.FindAsync(loanno);
                    if(loan == null)
                    {
                        //var original = loan.Copy();
                        loandetail.ApplyTo(loan);
                        await _context.SaveChangesAsync();
                    }
                    return loan;
                }
                 public async Task<Loandetail> UpdateLoan(int loanno, UpdateLoanDto loandetail)
        {
            try
            {
                var loan = await _context.Loandetails.FindAsync(loanno);
                if(loan != null)
                {
                    var UpdateData = new UpdateLoanDto()
                    {
                        
                        Loanamount = loandetail.Loanamount,
                        Loanterm = loandetail.Loanterm,
                        Loantype = loandetail.Loantype,
                        Propertyaddress = loandetail.Propertyaddress
                       
                        
                    };

                    await _context.SaveChangesAsync();
                    
                }
                return loan;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         
         
         
         */
    }

}
