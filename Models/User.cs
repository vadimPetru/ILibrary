using Microsoft.AspNetCore.Identity;

namespace ILibrary.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
