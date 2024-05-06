using Microsoft.EntityFrameworkCore;

namespace Ghoul.Models;

public class WastelandContext : DbContext
{
    public WastelandContext(DbContextOptions<WastelandContext> options) : base (options) { }
    
    public DbSet<Dweller> Dwellers { get; set; }
}