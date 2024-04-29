using System.ComponentModel.DataAnnotations;

namespace Author_API.DTO
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public bool isAdmin { get; set; }
    }
}
