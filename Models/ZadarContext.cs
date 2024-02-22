using Microsoft.EntityFrameworkCore;

namespace ZadarAPI.Models;

public class ZadarContext : DbContext
{
    public DbSet<Kvart> Kvarts { get; set; }
    public DbSet<Street> Streets { get; set; }
    
    public ZadarContext(DbContextOptions<ZadarContext> options) : base(options)
    {
    }
}