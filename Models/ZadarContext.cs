using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ZadarAPI.Models;

public class ZadarContext : IdentityDbContext<Resident>
{
    public DbSet<Kvart> Kvarts { get; set; }
    public DbSet<Street> Streets { get; set; }
    
    public ZadarContext(DbContextOptions<ZadarContext> options) : base(options)
    {
    }
}