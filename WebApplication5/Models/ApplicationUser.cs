using Microsoft.AspNetCore.Identity;

namespace WebApplication5.Models;

public class ApplicationUser:IdentityUser
{
    public string FistName { get; set; } = null!;
        public string LastName { get; set; } = null!; }                                 