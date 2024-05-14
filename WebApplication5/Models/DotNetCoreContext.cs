using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models;

public class DotNetCoreContext:IdentityDbContext<ApplicationUser>

{   
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public  DotNetCoreContext(DbContextOptions<DotNetCoreContext> options):base(options)
    {
        
    }
    
}