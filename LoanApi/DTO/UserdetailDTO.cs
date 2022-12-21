namespace LoanApi.DTO
{
    public class UserdetailDTO
    {
        public int Userid { get; set; }

        public string Firstname { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string password { get; set; } = null!;

        public string role { get; set; }
    }
}
