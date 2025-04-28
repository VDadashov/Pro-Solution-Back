using Microsoft.AspNetCore.Identity;

namespace ProSolution.Core.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireAt { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
