using System.ComponentModel.DataAnnotations;

namespace EGWalks.API.Models.Dto
{
    public class RegisterUserDto
    {
        [Required]
        [DataType(DataType.EmailAddress)] 
        public string UserName{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password{ get; set; }

        [Required]
        public string[] Roles { get; set; }
    }
}
