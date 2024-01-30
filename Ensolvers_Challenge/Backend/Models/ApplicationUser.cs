using Microsoft.AspNetCore.Identity;

namespace Ensolvers_Challenge.Backend.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Note> Notes { get; set; }
    }
}