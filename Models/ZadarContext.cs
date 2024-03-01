using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ZadarAPI.Models;

public class ZadarContext : IdentityDbContext
{
    public DbSet<Kvart> Kvarts { get; set; }
    public DbSet<Street> Streets { get; set; }
    
    public ZadarContext(DbContextOptions<ZadarContext> options) : base(options)
    {
    }
}