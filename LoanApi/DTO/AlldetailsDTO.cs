namespace LoanApi.DTO
{
    public class AlldetailsDTO
    {
        public int UserId { get; set; }

        public string Firstname { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public string Username { get; set; } = null!;

        public int Loanid { get; set; }
        
        public int Loannumber { get; set; }

        public string Propertyaddress { get; set; } = null!;

        public int Loanamount { get; set; }

        public string Loantype { get; set; } = null!;

        public string LoanTerm { get; set; } = null!;

    }
}
