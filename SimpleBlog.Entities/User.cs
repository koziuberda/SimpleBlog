using Microsoft.AspNetCore.Identity;

namespace SimpleBlog.Entities
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}