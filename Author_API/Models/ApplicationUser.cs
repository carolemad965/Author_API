using Microsoft.AspNetCore.Identity;
namespace Author_API.Models
{
    public class ApplicationUser:IdentityUser
    {     
        public bool isAdmin {  get; set; }
    }
}
