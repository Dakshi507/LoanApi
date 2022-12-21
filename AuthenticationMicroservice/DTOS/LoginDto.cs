using System.ComponentModel.DataAnnotations;

namespace AuthorizationMicroservice.DTOS
{
    public class LoginDto
    {

        
        //public int UserId { get; set; }

        public string UserName { get; set; }
        
        public string Password { get; set; }

       // public bool IsAdmin { get; set; } 

    }
}
