using System.ComponentModel.DataAnnotations;

namespace AuthorizationMicroservice.DTOS
{
    public class RegisterDto
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string role { get; set; } 
    }
}
