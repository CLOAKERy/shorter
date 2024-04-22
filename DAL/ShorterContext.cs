using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ShorterContext : DbContext
{
    public string ConnectionString;
    public ShorterContext(string connectionString)
    {
        ConnectionString = connectionString;
        
    }

    public ShorterContext(DbContextOptions<ShorterContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Link> Links { get; set; }
}