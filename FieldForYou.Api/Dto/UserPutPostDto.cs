using Domain;
using System.ComponentModel.DataAnnotations;

namespace FieldForYou.Api.Dto
{
    public class UserPutPostDto
    {
        [Required]
        
        public string Name { get; set; }
        [Required]
        
        public string Password { get; set; }

        [Required]
        
        public string Email { get; set; }

        [Required]
        
        public string Username { get; set; }

        [Required]
        
        public string PhoneNumber { get; set; }

        [Required]
        public Role Role { get; set; }

    }
}
