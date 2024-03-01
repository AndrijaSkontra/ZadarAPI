using Microsoft.AspNetCore.Identity;

namespace ZadarAPI.Models;

public class ApplicationUser : IdentityUser
{
    public Role Role { get; set; }
}