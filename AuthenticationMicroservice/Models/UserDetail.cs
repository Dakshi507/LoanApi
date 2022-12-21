using System.ComponentModel.DataAnnotations;




namespace AuthenticationMicroservice.Models
{
    public class UserDetail
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string role { get; set; } 

    }
}