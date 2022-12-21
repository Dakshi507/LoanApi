using LoanApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanApi.DTO
{
    public class LoandetailDTO
    {
        public int Loanid { get; set; }
        public int Loannumber { get; set; }

        public string Propertyaddress { get; set; } = null!;
        public int Loanamount { get; set; }
        public string Loantype { get; set; } = null!;
        public string Loanterm { get; set; }

        public string Firstname { get; set; }
       
        public string Lastname { get; set; } 
        public int? Userid { get; set; }
    }
}
