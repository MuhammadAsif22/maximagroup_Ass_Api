using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace eServicesApi.Model
{
    public class LoginUserDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password lenght should be Greate or equally to 6")]
        public string Password { get; set; }
    }

    public class UserDTO : LoginUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }

        public ICollection<string> Roles { get; set; }
        
    }
}
